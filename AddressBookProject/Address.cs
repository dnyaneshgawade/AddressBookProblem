using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookProject
{
    class Address
    {
        public static List<AddressBook> Contacts = new List<AddressBook>();
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
            Contacts.Add(addressbook);
        }
        public void Display(AddressBook person)
        {
            Console.WriteLine("FirstName : " + person.FirstName + "\n" + "LastName : " + person.LastName + "\n" + "Address : " + person.Address + "\n"
                           + "State : " + person.State + "\n" + "City : " + person.City + "\n" + "Zip : " + person.Zip + "\n"
                           + "PhoneNumber : " + person.PhoneNumber + "\n" + "Mail Id : " + person.Email);
        }
        public static void Edit()
        {
            AddressBook addressBook = new AddressBook();
            Console.WriteLine("Enter the first name of the person to be edited :");
            String name = Console.ReadLine();
            foreach (var data in Contacts)
            {
                if (data.FirstName == name)
                {
                    Console.WriteLine("What do you want to edit: FirstName,Lastname,Address,City,State,PhoneNumber,Zip or EmailId");
                    String CheckEdit = Console.ReadLine().ToLower();
                    if (CheckEdit == "firstname")
                        data.FirstName = Console.ReadLine();
                    if (CheckEdit == "lastname")
                        data.LastName = Console.ReadLine();
                    if (CheckEdit == "addressname")
                        data.Address = Console.ReadLine();
                    if (CheckEdit == "city")
                        data.City = Console.ReadLine();
                    if (CheckEdit == "state")
                        data.State = Console.ReadLine();
                    if (CheckEdit == "phonenumber")
                        data.PhoneNumber = Convert.ToDouble(Console.ReadLine());
                    if (CheckEdit == "zip")
                        data.Zip = Convert.ToDouble(Console.ReadLine());
                    if (CheckEdit == "emailid")
                        data.Email = Console.ReadLine();
                }
                else
                    Console.WriteLine("contact not found");
            }
        }
        public void Delete()
        {
            Console.WriteLine("Enter the first name :");
            String firstname = Console.ReadLine();
            foreach (var data in Contacts)
            {

                if (data.FirstName.Equals(firstname))
                {
                    Contacts.Remove(data);
                    Console.WriteLine("contact deleted successfully");
                }
            }
        }
        public void ContactsDetails()
        {
            int Choice = 0;
            while (Choice != 4)
            {
                Console.WriteLine(" Enter 0 for Add new contact\n Enter 1 for Edit Existing contact\n Enter 2 for Display Contact\n Enter  3 for delete \n Enter 4 for exit ");
                Choice = Convert.ToInt32(Console.ReadLine());
                switch (Choice)
                {
                    case 0:
                        Add();
                        foreach (var person in Contacts)
                        {
                            Display(person);
                        }
                        break;
                    case 1:
                        Edit();
                        break;
                    case 2:
                        foreach (var person in Contacts)
                        {
                            Display(person);
                        }
                        break;
                    case 3:
                        Delete();
                        break;
                    default:
                        Console.WriteLine("Enter wrong input");
                        break;
                }
            }
        }
    }
}
