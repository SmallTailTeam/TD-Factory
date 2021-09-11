using System.Collections.Generic;
using System.Linq;
using SFML.Graphics;

namespace TdFactory.Core.Entities
{
    public class Item
    {
        public int StackSize { get; init; }
        public Texture Texture { get; init; }
        public List<ItemTag> Tags { get; init; } = new();

        public bool HasTag(string tagName)
        {
            return Tags.Any(tag => tag.Name == tagName);
        }

        public T EvaluateTag<T>(string tagName)
        {
            if (!HasTag(tagName))
            {
                return default;
            }

            return (T)Tags.FirstOrDefault(tag => tag.Name == tagName)?.Value;
        } 
    }
}