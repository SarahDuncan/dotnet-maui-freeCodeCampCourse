using Contacts.Models;

namespace Contacts.Views;

//[QueryProperty(nameof(ContactId), "Id")]
public partial class EditContactPage : ContentPage
{
    private Models.Contact contact;

    public EditContactPage()
	{
		InitializeComponent();
	}

 //   private void btnCancel_Clicked(object sender, EventArgs e)
 //   {
	//	Shell.Current.GoToAsync("..");
 //   }

 //   public string ContactId 
	//{
	//	set
	//	{
	//		contact = ContactRepository.GetContactById(int.Parse(value));
	//		lbl.Text = contact.Name;
	//	}
	//}
}