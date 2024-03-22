using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassBook.Data.Entities
{
	public class Student
	{
		[Key]
		public string Id { get; set; }

		[Required]
		public int NumberInClass { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public string Surname { get; set; }

		[Required]
		[ForeignKey("Class")]
		public string ClassId { get; set; }

		public virtual Class Class { get; set; }

		



		public Student()
		{
		}

		public Student(int numberInClass, string name, string surname, string Class)
		{
			this.Id = Guid.NewGuid().ToString();
			this.NumberInClass = numberInClass;
			this.Name = name;
			this.Surname = surname;
			this.ClassId = Class;
		}
	}
}

