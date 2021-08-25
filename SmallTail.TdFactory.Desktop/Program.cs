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
            
            using GameHeart game = new ();
            game.Run();
        }
    }
}