using Contacts.Models;

namespace Contacts.Views;

[QueryProperty(nameof(ContactId), "Id")]
public partial class EditContactPage : ContentPage
{
    private Models.Contact contact;

    public EditContactPage()
	{
		InitializeComponent();
	}

	private void btnCancel_Clicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("..");
	}

	public string ContactId
	{
		set
		{
			contact = ContactRepository.GetContactById(int.Parse(value));

			if (contact != null)
			{
				entryName.Text = contact.Name;
				entryEmail.Text = contact.Email;
				entryPhoneNumber.Text = contact.PhoneNumber;
				entryAddress.Text = contact.Address;
			}
		}
	}

    private void btnUpdate_Clicked(object sender, EventArgs e)
    {
		contact.Name = entryName.Text;
		contact.Email = entryEmail.Text;
		contact.PhoneNumber = entryPhoneNumber.Text;
		contact.Address = entryAddress.Text;

        ContactRepository.UpdateContact(contact.Id, contact);
		Shell.Current.GoToAsync("..");
    }
}