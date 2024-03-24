using System;
namespace ClassBook.Services
{
	public class GradeService : IGradeService
	{
		private IGradeRepository gradeRepository;
		private IStudentService studentService;

		public GradeService(IGradeRepository gradeRepository, IStudentService studentService)
		{
			this.gradeRepository = gradeRepository;
			this.studentService = studentService;
		}

		public void Add(CreateGradeViewModel model)
		{
			if (model == null)
				throw new Exception("Trying to add a NULL object!");
			var grade = new Grade(model.Grade, model.Subject, model.student.Id);
			gradeRepository.Add(grade);
		}

		public ICollection<Grade> GetAllByStudentIdAndSubjectId(string studentId, string subjectId)
		{
			var entities = gradeRepository.GetAllByStudentIdAndSubjectId(studentId, subjectId);
			return entities;
		}

        public IEnumerable<GradeViewModel> GetAll(int numberInClass, string Class)
		{
			var entities = gradeRepository.GetAll(studentService.GetStudentId(numberInClass, Class));
			return entities;
		}

		public void Delete(int gradeId)
		{
			gradeRepository.Delete(gradeId);
		}
    }
}

