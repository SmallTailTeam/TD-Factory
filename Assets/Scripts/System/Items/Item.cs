using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using TdFactory.System.Items.Crafting;
using UnityEngine;

namespace TdFactory.System.Items
{
    public class Item
    {
        public string Id { get; set; }
        public int StackSize { get; set; }
        public Sprite Sprite { get; set; }
        public List<ItemTag> Tags { get; set; } = new List<ItemTag>();
        public ItemCraft Craft { get; set; } = null;

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