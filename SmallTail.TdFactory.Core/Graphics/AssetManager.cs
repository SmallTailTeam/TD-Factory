using System.Collections.Generic;
using SFML.Graphics;

namespace TdFactory.Core.Graphics
{
    public static class AssetManager
    {
        private static Dictionary<string, object> _assets = new();

        public static Texture LoadTexture(string path)
        {
            if (_assets.ContainsKey(path))
            {
                return _assets[path] as Texture;
            }

            Texture texture = new (path);
            _assets[path] = texture;
            
            return texture;
        }

        public static Font LoadFont(string path)
        {
            if (_assets.ContainsKey(path))
            {
                return _assets[path] as Font;
            }

            Font texture = new (path);
            _assets[path] = texture;
            
            return texture;
        }
    }
}