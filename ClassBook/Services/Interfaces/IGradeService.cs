using System;
namespace ClassBook.Services.Interfaces
{
	public interface IGradeService
	{
        void Add(CreateGradeViewModel model);

        //void Delete(int id);

        //Grade Get(int id);

        ICollection<Grade> GetAllByStudentIdAndSubjectId(string id1, int id2);

        IEnumerable<GradeViewModel> GetAll(int numberInClass, string Class);
    }
}

