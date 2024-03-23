using System;
namespace ClassBook.Models.Student
{
	public class CreateStudentViewModel
	{
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int NumberInClass { get; set; }
        public string Class { get; set; }



        public CreateStudentViewModel(string id, string name, int numberInClass, string surname, string Class)
        {
            Id = id;
            Name = name;
            Surname = surname;
            NumberInClass = numberInClass;
            this.Class = Class;


        }
    }
}


