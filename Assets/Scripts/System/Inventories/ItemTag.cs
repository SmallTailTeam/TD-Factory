namespace TdFactory.System.Inventories
{
    public class ItemTag
    {
        public string Name { get; }
        public object Value { get; }

        public ItemTag(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }
}