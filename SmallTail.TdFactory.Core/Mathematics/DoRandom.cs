using System;

namespace TdFactory.Core.Mathematics
{
    public static class DoRandom
    {
        private static Random _random = new();

        public static int Generate(int a, int b)
        {
            return _random.Next(a, b);
        }
    }
}