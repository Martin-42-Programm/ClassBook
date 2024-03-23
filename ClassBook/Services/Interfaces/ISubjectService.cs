using System;
namespace ClassBook.Services.Interfaces
{
	public interface ISubjectService
	{
        List<Subject> List();

        void Delete(Subject subject);

        void Add(Subject subject);

        Subject GetSubjectById(string subject);
    }
}

