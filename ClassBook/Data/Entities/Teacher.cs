using System;
using System.ComponentModel.DataAnnotations;

namespace ClassBook.Data.Entities
{
	public class Teacher
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
		public string Subject { get; set; }


        public Teacher()
		{
		}

		public Teacher(string name, string surname, string subject)
		{
			this.Name = name;
			this.Surname = surname;
			this.Subject = subject;
		}

        public Teacher(int id, string name, string surname, string subject)
        {

			this.Id = id;
			this.Name = name;
            this.Surname = surname;
            this.Subject = subject;
        }
    }
}

