using System;
namespace ClassBook.Repository.Interfaces
{
	public interface ITeacherRepository
	{

		void Add(Teacher teacher);

		IEnumerable<Teacher> GetTeachersWithSubject(string subject);

    }
}

