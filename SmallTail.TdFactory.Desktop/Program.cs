using SmallTail.TdFactory.Core;

namespace SmallTail.TdFactory.Desktop
{
    internal static class Program
    {
        private static void Main()
        {
            Game game = new (new TestingState());
        }
    }
}