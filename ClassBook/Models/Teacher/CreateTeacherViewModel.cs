using System;
namespace ClassBook.Models
{
	public class CreateTeacherViewModel
	{
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Subject { get; set; }

		

        public CreateTeacherViewModel(string id, string name, string surname, string subject)
		{
			Id = id;
			Name = name;
			Surname = surname;
			Subject = subject;
			

		}
	}
}

