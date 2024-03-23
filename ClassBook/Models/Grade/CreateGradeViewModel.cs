using System;
using ClassBook.Data.Entities;

namespace ClassBook.Models
{
	public class CreateGradeViewModel
	{
		public Data.Entities.Student student { get; set; }

		public string Class { get; set; }

		public double Grade { get; set; }

		public Subject Subject { get; set; }



		public CreateGradeViewModel(Data.Entities.Student student, string Class, double grade, Subject subject)
		{
			this.student = student;
			this.Class = Class;
			this.Grade = grade;
			this.Subject = subject;
		}
	}
}

