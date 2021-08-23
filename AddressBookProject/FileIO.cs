using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AddressBookProject
{
    public class FileIO
    {
        public static string filepath = @"C:\Users\dnyan\dnyana\AddressBookProblem\AddressBookProject\Contacts.txt";
        public static void WriteToFile(Dictionary<string, List<AddressBook>> dict, string filepath)
        {
            if (File.Exists(filepath))
            {
                if (dict.Count > 0)
                {
                    using (StreamWriter streamWriter = new StreamWriter(filepath))
                    {
                        Console.WriteLine("Writing contacts to text file");
                        foreach (KeyValuePair<string, List<AddressBook>> persons in dict)
                        {
                            foreach (AddressBook contacts in persons.Value)
                            {
                                streamWriter.WriteLine("First name :" + contacts.FirstName+ "  Last name :" + contacts.LastName+ "  Address :" + contacts.Address+ "  City :" + contacts.City+ "  State :" + contacts.State+ "  Zip :" + contacts.Zip+ "  Phone Number :" + contacts.PhoneNumber+ "  Email :" + contacts.Email);
                               
                            }
                        }
                        streamWriter.Close();
                    }
                }
                else
                {
                    Console.WriteLine("Addressbook is Empty. try again...");
                }
                
            }
            else
            {
                Console.WriteLine("File not exists");
            }
        }
        public void ReadFile(string filePath)
        {
            Console.WriteLine("...........Data of Text File is ............");
            using (StreamReader file = new StreamReader(filepath))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
}
