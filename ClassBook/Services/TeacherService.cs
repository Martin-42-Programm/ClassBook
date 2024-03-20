using System;
namespace ClassBook.Services
{
	public class TeacherService : ITeacherService
	{
		private ITeacherRepository teacherRepository;

		public TeacherService(ITeacherRepository teacherRepository)
		{
			this.teacherRepository = teacherRepository;
		}

		public void Add(CreateTeacherViewModel model)
		{
			var teacher = new Teacher(model.Name, model.Surname, model.Subject);
			teacherRepository.Add(teacher);
		}
	}
}

