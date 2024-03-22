using System;
namespace ClassBook.Repository.Interfaces
{
	public interface IStudentRepository
	{
		IEnumerable<Student> GetAll();

		Student GetById(int id);

        List<Student> ExtractStudentsFromClass(string className);

        string GetStudentId(int numberInClass, string Class);
    }
}

