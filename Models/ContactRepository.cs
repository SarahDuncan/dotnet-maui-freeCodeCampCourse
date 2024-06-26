﻿namespace Contacts.Models
{
    public static class ContactRepository
    {
        public static List<Contact> _contacts = new List<Contact>()
        {
            new Contact
            {
                Id = 1,
                Name = "John Doe",
                Email = "johndoe@email.com"
            },
            new Contact
            {
                Id = 2,
                Name = "Jane Doe",
                Email = "janedoe@email.com"
            },
            new Contact
            {
                Id = 3,
                Name = "Tom Hanks",
                Email = "tomhanks@email.com"
            },
            new Contact
            {
                Id = 4,
                Name = "Taylor Swift",
                Email = "taylorswift@email.com"
            }
        };

        public static List<Contact> GetContacts() => _contacts;

        public static Contact GetContactById(int id)
        {
            var contact = _contacts.FirstOrDefault(c => c.Id == id);

            if (contact != null)
            {
                return new Contact
                {
                    Id = contact.Id,
                    Name = contact.Name,
                    Email = contact.Email,
                    PhoneNumber = contact.PhoneNumber,
                    Address = contact.Address
                };
            }

            return null;
        }

        public static void UpdateContact(int id, Contact contact)
        {
            if (id != contact.Id)
            {
                return;
            }

            var contactToUpdate = _contacts.FirstOrDefault(c => c.Id == id);

            if (contactToUpdate != null)
            {
                contactToUpdate.Name = contact.Name;
                contactToUpdate.Email = contact.Email;
                contactToUpdate.PhoneNumber = contact.PhoneNumber;
                contactToUpdate.Address = contact.Address;
            }
        }

        public static void AddContact(Contact contact)
        {
            var maxId = _contacts.Max(x => x.Id);

            contact.Id = maxId + 1;
            _contacts.Add(contact);
        }

        public static void RemoveContact(int id)
        {
            var contactToDelete = _contacts.FirstOrDefault(x => x.Id == id);

            if (contactToDelete != null)
            {
                _contacts.Remove(contactToDelete);
            }
        }

        public static List<Contact>? SearchContacts(string input)
        {
            var contacts = _contacts.Where(c => !string.IsNullOrWhiteSpace(c.Name) 
            && c.Name.StartsWith(input, StringComparison.OrdinalIgnoreCase)).ToList();

            if (contacts == null || contacts.Count == 0)
            {
                contacts = _contacts.Where(c => !string.IsNullOrWhiteSpace(c.Email) &&
                c.Email.StartsWith(input, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else return contacts;

            if (contacts == null || contacts.Count == 0)
            {
                contacts = _contacts.Where(c => !string.IsNullOrWhiteSpace(c.PhoneNumber)  &&
                c.PhoneNumber.StartsWith(input, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else return contacts;

            if (contacts == null || contacts.Count == 0)
            {
                contacts = _contacts.Where(c => !string.IsNullOrWhiteSpace(c.Address)  &&
                c.Address.StartsWith(input, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else return contacts;

            return contacts;
        }
    }
}
