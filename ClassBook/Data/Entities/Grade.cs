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


		public virtual Subject Subject { get; set; }


        [ForeignKey("Student")]
        public string StudentId { get; set; }


        public virtual Student Student { get; set; }


        public Grade()
        {
        }

        public Grade(double note, Subject subject, Student student)
		{
			this.Note = note;
			this.Subject = subject ;
			this.SubjectId = subject.Id;
			this.StudentId = student.Id;
		}

        public Grade(double note, Subject subject, string studentId)
        {
            this.Note = note;
            this.Subject = subject;
            this.SubjectId = subject.Id;
            this.StudentId = studentId;
        }



        public Grade(double note, int subjectId, string studentId)
        {
            this.Note = note;
            this.SubjectId = subjectId;
            this.StudentId = studentId;
        }

        public override bool Equals(object? other)
            => Equals((Grade)other);

        public bool Equals(Grade other)
            => other != null &&
                Note == other.Note &&
                StudentId == other.StudentId &&
                SubjectId == other.SubjectId; 





    }
}

