using System;
namespace ClassBook.Repository.Interfaces
{
	public interface IStudentRepository
	{
		IEnumerable<Student> GetAll();

		Student GetById(string id);

        List<Student> ExtractStudentsFromClass(string className);

        string GetStudentId(int numberInClass, string Class);

        IEnumerable<Student> GetStudentsWithClass(string Class);

        void Add(Student student);
        
    }
}

