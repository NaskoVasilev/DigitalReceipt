namespace DigitalReceipt.Models.Common
{
    public class GroupingEntityViewModel<TKey, TValue>
    {
        public TKey Key { get; set; }

        public TValue Value { get; set; }
    }
}
