using System;
namespace ClassBook.Repository.Interfaces
{
	public interface IStudentRepository
	{
		IEnumerable<Student> GetAll();

		Student GetById(int id);
	}
}

