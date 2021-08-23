using System;

namespace AddressBookProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wellcome to Addressbook");
            AddressBookMain address = new AddressBookMain();
            address.ContactsDetails();
        }
    }
}
