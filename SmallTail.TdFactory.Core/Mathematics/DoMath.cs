using System;

namespace TdFactory.Core.Mathematics
{
    public static class DoMath
    {
        public static int RoundToInt(float x)
        {
            return (int) MathF.Round(x);
        }
    }
}