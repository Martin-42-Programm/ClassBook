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

		public Student(string id, int numberInClass, string name, string surname, Class Class)
		{
			this.Id = id;
			this.NumberInClass = numberInClass;
			this.Name = name;
			this.Surname = surname;
			this.ClassId = Class.Id;
		}
        public Student(string id, int numberInClass, string name, string surname, string Class)
        {
            this.Id = id;
            this.NumberInClass = numberInClass;
            this.Name = name;
            this.Surname = surname;
            this.ClassId = Class;
        }
    }
}

