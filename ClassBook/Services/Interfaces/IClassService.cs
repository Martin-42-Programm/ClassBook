using System;
namespace ClassBook.Services.Interfaces
{
	public interface IClassService
	{
       List<Class> List();

        void Delete(Class Class);

        void Add(Class Class);

        Class GetClassByName(string className);
    }
}

