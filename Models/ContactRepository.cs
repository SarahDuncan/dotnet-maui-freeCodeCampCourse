namespace Contacts.Models
{
    public static class ContactRepository
    {
        public static List<Contact> _contacts = new List<Contact>()
        {
            new Contact
            {
                Name = "John Doe",
                Email = "johndoe@email.com"
            },
            new Contact
            {
                Name = "Jane Doe",
                Email = "janedoe@email.com"
            },
            new Contact
            {
                Name = "Tom Hanks",
                Email = "tomhanks@email.com"
            },
            new Contact
            {
                Name = "Taylor Swift",
                Email = "taylorswift@email.com"
            }
        };

        public static List<Contact> GetContacts() => _contacts;
        public static Contact GetContactById(int id) => _contacts.FirstOrDefault(c => c.Id == id);

    }
}
