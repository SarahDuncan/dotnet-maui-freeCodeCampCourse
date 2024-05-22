namespace Contacts.Views;

public partial class ContactsPage : ContentPage
{
	public ContactsPage()
	{
		InitializeComponent();

        List<Contact> contacts = new List<Contact>()
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

        listContacts.ItemsSource = contacts;
	}

    public class Contact
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}