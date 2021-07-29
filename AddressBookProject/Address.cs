using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookProject
{
    class Address
    {
        public void Add()
        {
            AddressBook addressbook = new AddressBook();
            Console.WriteLine("enter Firstname,LastName,Adress,State,City,Zip,Phonenumber,Mail");
            addressbook.FirstName = Console.ReadLine();
            addressbook.LastName = Console.ReadLine();
            addressbook.Address = Console.ReadLine();
            addressbook.State = Console.ReadLine();
            addressbook.City = Console.ReadLine();
            addressbook.Zip = Convert.ToDouble(Console.ReadLine());
            addressbook.PhoneNumber = Convert.ToDouble(Console.ReadLine());
            addressbook.Email = Console.ReadLine();
        }
    }
}
