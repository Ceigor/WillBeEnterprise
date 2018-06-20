namespace WillBeEnterprise.Models
{
    public class StringSelectable : ISelectable<string>
    {
        public StringSelectable(string value)
        {
            Value = value;
        }
    }
}
