using System;
namespace ClassBook.Services.Interfaces
{
	public interface ISubjectService
	{
        List<Subject> List();

        void Delete(string subject);

        void Add(string subject);

        Subject GetSubjectById(string subject);
    }
}

