using System;
namespace ClassBook.Models
{
	public class CreateGradeViewModel
	{
		public int NumberInClass { get; set; }

		public string Class { get; set; }

		public double Grade { get; set; }

		public Subject Subject { get; set; }



		public CreateGradeViewModel(int id, string Class, double grade, Subject subject)
		{
			this.NumberInClass = id;
			this.Class = Class;
			this.Grade = grade;
			this.Subject = subject;
		}
	}
}

