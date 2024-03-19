using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassBook.Data.Entities
{
	public class Absence
	{

		[Key]
		public int Id { get; set; }

		[Required]
		public bool IsRespectful { get; set; }

		[Required]
		public DateTime Date
		{
			get
			{
				return Date;
			}
			set
			{
				Date = DateTime.Now;
			}
		}

		[Required]
		[ForeignKey("Student")]
		public int StudentId { get; set; }

		public Student Student { get; set; }

        [Required]
        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }

        public Student Teacher { get; set; }

        public Absence()
		{
		}

		public Absence(bool isRespectful, DateTime date, int studentId, int teacherId)
		{
			this.IsRespectful = isRespectful;
			this.Date = date;
			this.StudentId = studentId;
			this.TeacherId = teacherId;
		}
	}
}

