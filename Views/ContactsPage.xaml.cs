using Contacts.Models;
using System.Collections.ObjectModel;

namespace Contacts.Views;

public partial class ContactsPage : ContentPage
{
	public ContactsPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        searchBar.Text = string.Empty;
        LoadContacts();
    }

    private async void listContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (listContacts.SelectedItem != null)
        {
            await Shell.Current.GoToAsync($"{nameof(EditContactPage)}?Id={((Models.Contact)listContacts.SelectedItem).Id}");
        }
    }

    private void listContacts_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        listContacts.SelectedItem = null;
    }

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddContactPage));
    }

    private void DeleteItem_Clicked(object sender, EventArgs e)
    {
        var menuItem = sender as MenuItem;
        var contact = menuItem.CommandParameter as Models.Contact;

        ContactRepository.RemoveContact(contact.Id);
        DisplayAlert("Delete Contact", "Contact successfully deleted", "OK");
        LoadContacts();
        Shell.Current.GoToAsync("..");
    }

    private void LoadContacts()
    {
        var contacts = new ObservableCollection<Models.Contact>(ContactRepository.GetContacts());
        listContacts.ItemsSource = contacts;
    }

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        var contacts = new ObservableCollection<Models.Contact>(ContactRepository.SearchContacts(((SearchBar)sender).Text));
        listContacts.ItemsSource = contacts;
    }
}