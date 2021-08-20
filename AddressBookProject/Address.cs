﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBookProject
{
    class Address
    {
        public static int Choice;
        public static List<AddressBook> Contacts = new List<AddressBook>();
        public static Dictionary<string, List<AddressBook>> dict = new Dictionary<string, List<AddressBook>>();
        public void Add(Dictionary<string, List<AddressBook>> dict)
        {
            Console.WriteLine("Enter how many contacts do you want to add");
            int num = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                List<AddressBook> Contacts = new List<AddressBook>();
                List<AddressBook> lambda = new List<AddressBook>();
                AddressBook addressBook = new AddressBook();
                Console.WriteLine("Enter First Name");
                addressBook.FirstName = Console.ReadLine();
                
                var address = dict.Any(x => x.Key.Equals(addressBook.FirstName));
                if (address== false)
                { 
                    Console.WriteLine("Enter Last Name");
                    addressBook.LastName = Console.ReadLine();
                    Console.WriteLine("Enter address");
                    addressBook.Address = Console.ReadLine();
                    Console.WriteLine("Enter city");
                    addressBook.City = Console.ReadLine();
                    Console.WriteLine("Enter state");
                    addressBook.State = Console.ReadLine();
                    Console.WriteLine("Enter zip code");
                    addressBook.Zip = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Enter phone number");
                    addressBook.PhoneNumber = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Enter email");
                    addressBook.Email = Console.ReadLine();
                    Console.WriteLine("Person added successully...");
                    Contacts.Add(addressBook);
                    dict.Add(addressBook.FirstName, Contacts);
                }
                else
                {
                    Console.WriteLine("Person Already Exists!!! Please Enter Different Name ");
                    i -= 1;
                }
            }
        }
        public void Display(Dictionary<string, List<AddressBook>> dict)
        {
            int count = 1;
            if ((dict.Count) > 0)
            {
                foreach (KeyValuePair<string, List<AddressBook>> kvp in dict)
                {
                    foreach (AddressBook contacts in kvp.Value)
                    {

                        Console.WriteLine("Contact of :" + kvp.Key);
                        Console.WriteLine("First name :" + contacts.FirstName);
                        Console.WriteLine("Last name :" + contacts.LastName);
                        Console.WriteLine("Address :" + contacts.Address);
                        Console.WriteLine("City :" + contacts.City);
                        Console.WriteLine("State :" + contacts.State);
                        Console.WriteLine("Zip :" + contacts.Zip);
                        Console.WriteLine("Phone Number :" + contacts.PhoneNumber);
                        Console.WriteLine("Email :" + contacts.Email);
                        Console.WriteLine();
                        count++;
                    }
                }

            }
        }
        public static void Edit(Dictionary<string, List<AddressBook>> dict)
        {
            AddressBook addressBook = new AddressBook();
            List<AddressBook> Contacts = new List<AddressBook>();
            Console.WriteLine("Enter the first name of the person to be edited :");
            String name = Console.ReadLine();
            if (dict.ContainsKey(name))
            {
                Console.WriteLine("What do you want to edit: FirstName,Lastname,Address,City,State,PhoneNumber,Zip or EmailId");
                String CheckEdit = Console.ReadLine().ToLower();
                if (CheckEdit == "firstname")
                    addressBook.FirstName = Console.ReadLine();
                if (CheckEdit == "lastname")
                    addressBook.LastName = Console.ReadLine();
                if (CheckEdit == "addressname")
                    addressBook.Address = Console.ReadLine();
                if (CheckEdit == "city")
                    addressBook.City = Console.ReadLine();
                if (CheckEdit == "state")
                    addressBook.State = Console.ReadLine();
                if (CheckEdit == "phonenumber")
                    addressBook.PhoneNumber = Convert.ToDouble(Console.ReadLine());
                if (CheckEdit == "zip")
                    addressBook.Zip = Convert.ToDouble(Console.ReadLine());
                if (CheckEdit == "emailid")
                    addressBook.Email = Console.ReadLine();

                Console.WriteLine("Record Updated successfully...");
                Contacts.Add(addressBook);
                dict.Add(addressBook.FirstName, Contacts);
            }

        }
        public void ContactsDetails()
        {

            while (Choice != 4)
            {
                Console.WriteLine(" Enter 0 for Add new contact\n Enter 1 for Edit Existing contact\n Enter 2 for Display all contacts\nEnter 3 for sort by state or city \n Enter 4 for exit ");
                Choice = Convert.ToInt32(Console.ReadLine());
                switch (Choice)
                {
                    case 0:
                        Add(dict);
                        break;
                    case 1:
                        Edit(dict);
                        break;
                    case 2:
                        Display(dict);
                        break;
                    case 3:
                        SortUsingCityOrState(dict);
                        break;
                    default:
                        Console.WriteLine("Enter wrong input");
                        break;
                }
            }
        }
        public void SortUsingCityOrState(Dictionary<string, List<AddressBook>> dict)
        {
            if (dict.Count > 0)
            {
                Console.WriteLine("Enter City or State");
                List<AddressBook> sort = new List<AddressBook>();
                string search = Console.ReadLine().ToLower();
                switch (search)
                {
                    case "city":
                        Console.WriteLine("Enter City Name :");
                        string city = Console.ReadLine();
                        foreach (KeyValuePair<string, List<AddressBook>> peoples in dict)
                        {
                            sort = peoples.Value;
                        }
                        var check = sort.Any(x => x.City.Equals(city));
                        if (check)
                        {
                            var result = sort.Where(x => x.City.Contains(city));
                            foreach (var item in result)
                            {
                                Console.WriteLine("\nFirstname : "+item.FirstName+"\tCity : "+item.City);
                            }
                        }
                        else
                        {
                            Console.WriteLine("City not Found!");
                        }
                        break;
                    case "state":
                        Console.WriteLine("Enter City Name :");
                        string state = Console.ReadLine();
                        foreach (KeyValuePair<string, List<AddressBook>> peoples in dict)
                        {
                            sort = peoples.Value;
                        }
                        var checks = sort.Any(x => x.City.Equals(state));
                        if (checks)
                        {
                            var result = sort.Where(x => x.City.Contains(state));
                            foreach (var item in result)
                            {
                                Console.WriteLine("\nFirstname : " + item.FirstName + "\tState : " + item.State);
                            }
                        }
                        else
                        {
                            Console.WriteLine("State not Found!");
                        }
                        break;
                    default:
                        Console.WriteLine("try again");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Addressbook is Empty");
            }
        }
    }
}
