using System;
namespace ClassBook.Repository.Interfaces
{
	public interface IGradeRepository
	{

        void Add(Grade grade);

        void Delete(int id);

        Grade Get(int id);

        ICollection<Grade> GetAllByStudentIdAndSubjectId(int id1, int id2);

        IEnumerable<GradeViewModel> GetAll(int id);
    }
}

