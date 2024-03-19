using System;
namespace ClassBook.Repository.Interfaces
{
	public interface IGradeRepository
	{

        void Add(Grade grade);

        void Delete(int id);

        Grade Get(int id);
    }
}

