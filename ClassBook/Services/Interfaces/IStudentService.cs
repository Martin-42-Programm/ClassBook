using System;
namespace ClassBook.Services.Interfaces
{
	public interface IStudentService
	{

		IEnumerable<Student> GetAll();

		Student GetById(int id);

        List<Student> CreateAListOfStudents(string className);

		string GetStudentId(int numberInClass, string Class);

		IEnumerable<Student> GetStudentsWithClass(string Class);

		void Add(CreateStudentViewModel student);
    }
}

