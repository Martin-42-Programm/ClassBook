using System;
using System.ComponentModel.DataAnnotations;

namespace ClassBook.Data.Entities
{
	public class Student
	{
		[Key]
		public int NumberInClass { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public string Surname { get; set; }

		[Required]
		public string Class { get; set; }
		




		public Student()
		{
		}

		public Student(int numberInClass, string name, string surname, string Class)
		{
			this.NumberInClass = numberInClass;
			this.Name = name;
			this.Surname = surname;
			this.Class = Class;
		}
	}
}

