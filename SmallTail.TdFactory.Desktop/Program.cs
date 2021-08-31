using SmallTail.TdFactory.Game;

namespace SmallTail.TdFactory.Desktop
{
    internal static class Program
    {
        private static void Main()
        {
            GameDriver gameDriver = new ();
            gameDriver.Run();
        }
    }
}