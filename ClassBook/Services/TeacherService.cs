using System;
using ClassBook.Repository;

namespace ClassBook.Services
{
	public class TeacherService : ITeacherService
	{
		private readonly ITeacherRepository teacherRepository;
        private readonly ISubjectService subjectService;

        public TeacherService(ITeacherRepository teacherRepository, ISubjectService subjectService)
		{
			this.teacherRepository = teacherRepository;
			this.subjectService = subjectService;
		}

		public void Add(CreateTeacherViewModel model)
		{
			var name = model.Subject;
			var subjectEntity = subjectService.GetSubjectById(name);


			var teacher = new Teacher(model.Id, model.Name, model.Surname, subjectEntity);
			teacherRepository.Add(teacher);
		}

        public IEnumerable<Teacher> GetТeachersWithSubject(string subject)
        {
			
			var extractedTeachers = teacherRepository.GetTeachersWithSubject(subject);

            return extractedTeachers;
        }

		public Subject ExtractTeacherSubject(string teacherId)
		{
			var subject = teacherRepository.ExtractTeacherSubject(teacherId);

			if (subject == null)
                throw new Exception("Invalid teacher_Id!");

			return subject;
        }
    }
}

