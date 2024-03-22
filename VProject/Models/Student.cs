using System;
using System.ComponentModel.DataAnnotations;
namespace ElectronicSchoolDiary.Models
{
    class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Phone_number { get; set; }


        public Student(string name, string surname, string address, string phone_number)
        {
            {
                if (phone_number.Length != 0 || phone_number.Length == 9)
                {
                    Name = name;
                    Surname = surname;
                    Address = address;
                    Phone_number = phone_number;
                }
                else if(phone_number.Length > 0 && phone_number.Length != 9) throw new Exception("enter a nine digit phone number.");
            }
            
        }
    }
}