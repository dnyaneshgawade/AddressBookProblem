using System;

namespace AddressBookProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wellcome to Addressbook");
            Address address = new Address();
            address.ContactsDetails();
        }
    }
}
