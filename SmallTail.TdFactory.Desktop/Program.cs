using TdFactory.Core;

namespace TdFactory.Desktop
{
    internal static class Program
    {
        private static void Main()
        {
            Game game = new (new TestingState());
        }
    }
}