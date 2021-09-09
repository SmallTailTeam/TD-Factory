using SFML.Graphics;

namespace TdFactory.Core.Graphics
{
    public static class Shapes
    {
        public static Texture Square(uint width, uint height, Color color)
        {
            Image square = new (width, height);

            for (uint x = 0; x < square.Size.X; x++)
            {
                for (uint y = 0; y < square.Size.Y; y++)
                {
                    square.SetPixel(x, y, color);
                }
            }
            
            Texture texture = new (square);
            
            return texture;
        } 
    }
}