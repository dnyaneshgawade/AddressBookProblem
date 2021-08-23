using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBookProject
{
    class AddressBookMain
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public double Zip { get; set; }
        public double PhoneNumber { get; set; }
        public string Email { get; set; }
        
        public static int ContactCount=0;
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
                        ContactCount++;
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
        
        public void SortUsingCityOrState(Dictionary<string, List<AddressBook>> dict)
        {
            int number=0;
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
                                number += 1;
                            }
                            Console.WriteLine("Number of City's present in Addressbook: "+number);
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
                                number += 1;
                            }
                            Console.WriteLine("Number of States present in Addressbook: " + number);
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
                Console.WriteLine("Addressbook is Empty. try again...");
            }
        }

        public void SortDictionary(Dictionary<string, List<AddressBook>> dict)
        {
            if (dict.Count > 0)
            {
                Console.WriteLine("Addressbook Afer Sorting: ");
                foreach (var data in dict.OrderBy(x => x.Key))
                {
                    Console.WriteLine("{0}", data.Key);
                }
            }
            else
            {
                Console.WriteLine("Addressbook is Empty. try again...");
            }
        }
        public override string ToString()
        {
            return " First Name : " + this.FirstName + " \n Last Name : " + this.LastName + " \n Address : " + this.Address + "\n City : " + this.City + "\n State : " + this.State + "\n Zip : " + this.Zip + "\n PhoneNumber : " + this.PhoneNumber + "\n Email : " + this.Email;
        }

        public static void SortByCityStateOrZip(Dictionary<string, List<AddressBook>> dict)
        {
            
            List<AddressBook> list = new List<AddressBook>();
            foreach (var data in dict)
            {
                foreach (var item in data.Value)
                {
                    list.Add(item);
                }
            }
            while (Choice != 4)
            {
                Console.WriteLine("\n 1. for sort based on city \n 2. for sort based on State \n 3. for sort based on zip \n 4. for Exit \n Enter Your Cchoice ");
                Choice = Convert.ToInt16(Console.ReadLine());
                switch (Choice)
                {
                    case 1:
                        Console.WriteLine("\nDisplaying the list after sorting the citywise ");
                        foreach (var item in list.OrderBy(x => x.State))
                        {
                            Console.WriteLine(list.ToString());
                        }
                        break;
                    case 2:
                        Console.WriteLine("\nDisplaying the list after sorting the Statewise");
                        foreach (var item in list.OrderBy(x => x.Zip))
                        {
                            Console.WriteLine(list.ToString());
                        }
                        break;
                    case 3:
                        Console.WriteLine("\nDisplaying the list after sorting the ZipCodewise ");
                        foreach (var item in list.OrderBy(x => x.City))
                        {
                            Console.WriteLine(list.ToString());
                        }
                        break;
                    default:
                        Console.WriteLine("You Enter Wrong Input.. Try Again...");
                        break;
                }
            }
        }

        public void ContactsDetails()
        {

            while (Choice != 10)
            {
                Console.WriteLine(" Enter 0 for Add new contact\n Enter 1 for Edit Existing contact\n Enter 2 for Display all contacts\n Enter 3 for sort by state or city \n Enter 4 for Sort Using City or State\n Enter 5 for Display number of contacts present in Addressbook \n Enter 6 for sort whole dictionary \n Enter 7 For Sort by city, state or zip \n Enter 8 for write contacts to file \n Enter 9 for Read contacts from file\n Enter 10 for exit ");
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
                        Edit(dict);
                        break;
                    case 4:
                        SortUsingCityOrState(dict);
                        break;
                    case 5:
                        Display(dict);
                        Console.WriteLine("Contacts present in the AddressBook is: " + ContactCount + "\n");
                        break;

                    case 6:
                        SortDictionary(dict);
                        break;
                    case 7:
                        SortByCityStateOrZip(dict);
                        break;
                    case 8:
                        FileIO.WriteToFile(dict, FileIO.filepath);
                        break;
                    case 9:
                        FileIO fileIO = new FileIO();
                        fileIO.ReadFile(FileIO.filepath);
                        break;
                    default:
                        Console.WriteLine("Enter wrong input");
                        break;
                }
            }
        }
    }
}
