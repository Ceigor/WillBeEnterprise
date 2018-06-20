namespace WillBeEnterprise.Models
{
    public class ISelectable<T>
    {
        public bool Selected { get; set; }
        public T Value { get; set; }
    }
}
