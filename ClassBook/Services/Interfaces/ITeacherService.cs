using System;
namespace ClassBook.Services.Interfaces
{
	public interface ITeacherService
	{
		void Add(CreateTeacherViewModel teacher);

		IEnumerable<Teacher> GetТeachersWithSubject(string subject);

    }
}

