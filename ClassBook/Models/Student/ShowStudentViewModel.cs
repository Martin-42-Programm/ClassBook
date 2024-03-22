using System;
using System.ComponentModel.DataAnnotations;

namespace ClassBook.Models
{
	public class ShowStudentViewModel
	{
     
        
        public int NumberInClass { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Class { get; set; }



        public ShowStudentViewModel()
		{
		}

        public ShowStudentViewModel(int numberInClass, string name, string surname, Class Class)
        {
            this.NumberInClass = numberInClass;
            this.Name = name;
            this.Surname = surname;
            this.Class = Class.Id;
        }
	}
}

