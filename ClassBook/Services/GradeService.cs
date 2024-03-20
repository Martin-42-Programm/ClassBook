using System;
namespace ClassBook.Services
{
	public class GradeService : IGradeService
	{
		private IGradeRepository gradeRepository;

		public GradeService(IGradeRepository gradeRepository)
		{
			this.gradeRepository = gradeRepository;
		}

		public void Add(CreateGradeViewModel model)
		{
			var grade = new Grade(model.Grade, model.Subject, model.NumberInClass);
			gradeRepository.Add(grade);
		}

		public ICollection<Grade> GetAllByStudentIdAndSubjectId(int studentId, int subjectId)
		{
			var entities = gradeRepository.GetAllByStudentIdAndSubjectId(studentId, subjectId);
			return entities;
		}

        public IEnumerable<GradeViewModel> GetAll(int id)
		{
			var entities = gradeRepository.GetAll(id);
			return entities;
		}
    }
}

