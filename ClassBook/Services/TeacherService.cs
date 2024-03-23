using System;
using ClassBook.Repository;

namespace ClassBook.Services
{
	public class TeacherService : ITeacherService
	{
		private ITeacherRepository teacherRepository;
        private ISubjectService subjectService;

        public TeacherService(ITeacherRepository teacherRepository, ISubjectService subjectService)
		{
			this.teacherRepository = teacherRepository;
			this.subjectService = subjectService;
		}

		public void Add(CreateTeacherViewModel model)
		{
			var subject = subjectService.GetSubjectById(model.Subject);


			var teacher = new Teacher(model.Id, model.Name, model.Surname, subject);
			teacherRepository.Add(teacher);
		}

        public IEnumerable<Teacher> GetТeachersWithSubject(string subject)
        {
			
			var extractedTeachers = teacherRepository.GetTeachersWithSubject(subject);

            return extractedTeachers;
        }
    }
}

