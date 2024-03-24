using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassBook.Data.Entities
{
	public class Teacher
	{
		[Key]
		public string Id { get; set; }

		[Required]
		public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
		[ForeignKey("Subject")]
		public string SubjectName { get; set; }

		public virtual Subject Subject { get; set; }

        public Teacher()
		{
		}

		/*public Teacher(string name, string surname, Subject subject)
		{
			this.Name = name;
			this.Surname = surname;
			this.SubjectName = subject.Name;
		}*/

        public Teacher(string id, string name, string surname, Subject subject)
        {
            if (subject == null)
            {
                throw new ArgumentNullException(nameof(subject), "Subject cannot be null.");
            }
            this.Id = id;
			this.Name = name;
            this.Surname = surname;
			this.Subject = subject;
            this.SubjectName = subject.Name;
        }
    }
}

