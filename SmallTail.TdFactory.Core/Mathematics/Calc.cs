using System;

namespace TdFactory.Core.Mathematics
{
    public static class Calc
    {
        public static int RoundToInt(float x)
        {
            return (int) MathF.Round(x);
        }
    }
}