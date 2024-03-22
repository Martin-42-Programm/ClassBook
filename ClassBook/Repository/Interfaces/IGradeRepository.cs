using System;
namespace ClassBook.Repository.Interfaces
{
	public interface IGradeRepository
	{

        void Add(Grade grade);

        void Delete(int id);

        Grade Get(int id);

        ICollection<Grade> GetAllByStudentIdAndSubjectId(string id1, string id2);

        IEnumerable<GradeViewModel> GetAll(string id);

        
    }
}

