using System;
namespace ClassBook.Models
{
	public class CreateGradeViewModel
	{
		public Student student { get; set; }

		public string Class { get; set; }

		public double Grade { get; set; }

		public Subject Subject { get; set; }



		public CreateGradeViewModel(Student student, string Class, double grade, Subject subject)
		{
			this.student = student;
			this.Class = Class;
			this.Grade = grade;
			this.Subject = subject;
		}
	}
}

