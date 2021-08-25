using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Serilog;

namespace SmallTail.TdFactory.Core.Modding
{
    public class ModLoadingState : GameState
    {
        private const string _modsDirectory = "Mods";
        private GameHeart _game;
        
        public override void Initialize(GameHeart game)
        {
            _game = game;
            Task.Run(LoadMods);
        }

        private Task LoadMods()
        {
            try
            {
                Log.Information("Loading mods...");

                DirectoryInfo modsDirectory = new(_modsDirectory);

                if (!modsDirectory.Exists)
                {
                    modsDirectory = Directory.CreateDirectory(_modsDirectory);
                }

                List<Assembly> assemblies = LoadAssemblies(modsDirectory);
                List<Mod> mods = InstantiateMods(assemblies);
                
                mods.ForEach(mod => mod.Loaded(_game));
                mods.ForEach(mod => mod.PostLoaded(_game));
                
                Log.Information("Loaded {0} mods", assemblies.Count);
            }
            catch (Exception e)
            {
                Log.Error("Mod loading exception{0}{1}", Environment.NewLine, e);
            }

            return Task.CompletedTask;
        }

        private List<Assembly> LoadAssemblies(DirectoryInfo modsDirectory)
        {
            List<Assembly> assemblies = new ();

            foreach (DirectoryInfo modDirectory in modsDirectory.GetDirectories())
            {
                DirectoryInfo assembliesDirectory = new(modDirectory.FullName + $"{Path.DirectorySeparatorChar}Assemblies");

                foreach (FileInfo fileInfo in assembliesDirectory.GetFiles("*.dll"))
                {
                    assemblies.Add(Assembly.LoadFile(fileInfo.FullName));
                }
            }

            return assemblies;
        }

        private List<Mod> InstantiateMods(List<Assembly> assemblies)
        {
            List<Mod> mods = new ();
            
            foreach (Assembly assembly in assemblies)
            {
                IEnumerable<Type> modTypes = assembly.GetTypes()
                    .Where(type => type.BaseType == typeof(Mod));

                foreach (Type modType in modTypes)
                {
                    if (Activator.CreateInstance(modType) is Mod mod)
                    {
                        mods.Add(mod);
                    }
                }
            }

            return mods;
        }
    }
}