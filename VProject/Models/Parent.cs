using System;
using System.ComponentModel.DataAnnotations;

namespace ElectronicSchoolDiary.Models
{
    class Parent
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone_number { get; set; }


        public Parent( string name, string surname, string address,string email, string phone_number)
        {
            if (phone_number != "" || phone_number.Length == 9 )
            {
                Name = name;
                Surname = surname;
                Address = address;
                Email = email;
                Phone_number = phone_number;
            }
            else
                throw new Exception("enter a nine digit phone number");
        }
    }
}
