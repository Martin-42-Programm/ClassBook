using System;
namespace ClassBook.Repository.Interfaces
{
	public interface ISubjectRepository
	{
        List<Subject> List();

        void Delete(Subject subject);

        void Add(Subject subject);

        Subject GetSubjectById(string subject);
    }
}

