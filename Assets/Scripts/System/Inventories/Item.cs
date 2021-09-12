using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TdFactory.System.Inventories
{
    public class Item
    {
        public int StackSize { get; set; }
        public Sprite Sprite { get; set; }
        public List<ItemTag> Tags { get; set; } = new List<ItemTag>();

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