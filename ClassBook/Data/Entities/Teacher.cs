using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
		[ForeignKey("Subject")]
		public int SubjectId { get; set; }

		public virtual Subject Subject { get; set; }

        public Teacher()
		{
		}

		public Teacher(string name, string surname, Subject subject)
		{
			this.Name = name;
			this.Surname = surname;
			this.SubjectId = subject.Id;
		}

        public Teacher(int id, string name, string surname, Subject subject)
        {

			this.Id = id;
			this.Name = name;
            this.Surname = surname;
            this.SubjectId = subject.Id;
        }
    }
}

