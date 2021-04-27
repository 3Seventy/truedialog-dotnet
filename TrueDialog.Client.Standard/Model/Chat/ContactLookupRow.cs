namespace TrueDialog.Model
{
    public class ContactLookupRow : Base
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public bool Unsubscribed { get; set; }
        public bool Stopped { get; set; }
    }
}
