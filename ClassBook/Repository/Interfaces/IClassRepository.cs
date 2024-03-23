using System;
namespace ClassBook.Repository.Interfaces
{
	public interface IClassRepository
	{
        List<Class> List();

        void Delete(Class Class);

        void Add(Class Class);

        Class GetClassByName(string Class);
    }
}

