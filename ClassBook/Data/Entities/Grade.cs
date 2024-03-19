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
		public double Note
		{
			get
			{
				return Note;
			}

			set
			{
				if (value >= 2 && value <= 6)
					Note = value ;
				else
					throw new InvalidDataException("Not a valid grade!");
			}
		}

		
		[ForeignKey("Teacher")]
		public int TeacherId { get; set; }


		public Teacher Teacher { get; set; }


        [ForeignKey("Student")]
        public int StudentId { get; set; }


        public Student Student { get; set; }




		public Grade(int note, int teacherId, int studentid)
		{
			this.Note = note;
			this.TeacherId = teacherId;
			this.StudentId = studentid;
		}



        public Grade()
		{
		}
	}
}

