using System;
using ClassBook.Services;

namespace ClassBook.Models
{
	public class GradeViewModel
	{
		

		public int NumberInClass { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
        public string Subject { get; set; }
        public ICollection<Grade> GradesInCertainSubject { get; set; }



		public GradeViewModel(Data.Entities.Student student, string subject, ICollection<Grade> grades)
		{
			this.NumberInClass = student.NumberInClass;
			this.Name = student.Name;
			this.Surname = student.Surname;
			this.Subject = subject;
			this.GradesInCertainSubject = grades;


		}
        
        


    }
}

