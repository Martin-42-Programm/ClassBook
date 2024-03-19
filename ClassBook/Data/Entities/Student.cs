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
		public string Class
		{
			get
			{
				return Class;
			}
			set
			{
				var number = int.Parse(value.Substring(0, 2));

				if (number > 0 && number < 13)
					Class = value;
				else
					throw new InvalidDataException("Invalid class!");
			}
		}




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

