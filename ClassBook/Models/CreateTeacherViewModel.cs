using System;
namespace ClassBook.Models
{
	public class CreateTeacherViewModel
	{
		public string Name { get; set; }
        public string Surname { get; set; }
        public Subject Subject { get; set; }




        public CreateTeacherViewModel(string name, string surname, string subject)
		{
			Name = name;
			Surname = surname;
			Subject = new Subject(subject);

		}
	}
}

