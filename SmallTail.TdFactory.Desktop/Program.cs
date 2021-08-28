using Serilog;
using SmallTail.TdFactory.Core;

namespace SmallTail.TdFactory.Desktop
{
    internal static class Program
    {
        private static void Main()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            
            using GameCore game = new ();
            game.Run();
        }
    }
}