using System;
using SFML.Graphics;
using SFML.Window;
using Steamworks;

namespace SmallTail.TdFactory.Game
{
    public class GameDriver
    {
        private RenderWindow _window;

        public void Run()
        {
            _window = new RenderWindow(VideoMode.DesktopMode, "TD Factory");

            _window.Closed += (_, _) =>
            {
                _window.Close();
            };
            
            Initialize();

            DateTime lastUpdate = DateTime.Now;

            while (_window.IsOpen)
            {
                TimeSpan deltaTime = DateTime.Now - lastUpdate;
                lastUpdate = DateTime.Now;

                Update((float)deltaTime.TotalSeconds);
                    
                _window.Clear(Color.Black);
                Render();

                _window.Display();
                _window.DispatchEvents();
            }
        }

        private void Initialize()
        {
            SteamClient.Init(480);
        }
        
        private void Update(float deltaTime)
        {
            SteamClient.RunCallbacks();
        }

        private void Render()
        {
            
        }
    }
}