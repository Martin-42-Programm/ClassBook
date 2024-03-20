using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassBook.Data.Entities
{
	public class Grade
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public double Note { get; set; }

		
		[ForeignKey("Subject")]
		public int SubjectId { get; set; }


		public Subject Subject { get; set; }


        [ForeignKey("Student")]
        public int StudentId { get; set; }


        public Student Student { get; set; }


        public Grade()
        {
        }

        public Grade(double note, Subject subject, Student student)
		{
			this.Note = note;
			this.Subject = subject ;
			this.SubjectId = subject.Id;
			this.StudentId = student.NumberInClass;
		}

        public Grade(double note, Subject subject, int studentId)
        {
            this.Note = note;
            this.Subject = subject;
            this.SubjectId = subject.Id;
            this.StudentId = studentId;
        }






    }
}

