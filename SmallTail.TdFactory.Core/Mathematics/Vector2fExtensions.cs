using System;
using SFML.System;

namespace TdFactory.Core.Mathematics
{
    public static class Vector2fExtensions
    {
        public static float Length(this Vector2f vec)
        {
            return MathF.Sqrt(vec.X * vec.X + vec.Y * vec.Y);
        }
        
        public static bool NonZero(this Vector2f vec)
        {
            return vec.X != 0 || vec.Y != 0;
        }
        
        public static Vector2f Normalized(this Vector2f vec)
        {
            float length = MathF.Sqrt(vec.X * vec.X + vec.Y * vec.Y);
            return new Vector2f(vec.X / length, vec.Y / length);
        }
    }
}