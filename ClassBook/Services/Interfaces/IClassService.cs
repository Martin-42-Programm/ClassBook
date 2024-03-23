using System;
namespace ClassBook.Services.Interfaces
{
	public interface IClassService
	{
       List<Class> List();

        void Delete(string Class);

        void Add(string Class);

        Class GetClassByName(string className);
    }
}

