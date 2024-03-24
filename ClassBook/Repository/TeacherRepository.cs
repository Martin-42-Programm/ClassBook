using System;
using ClassBook.Repository.Interfaces;

namespace ClassBook.Repository
{
	public class TeacherRepository : ITeacherRepository
	{
		private ApplicationContext context;


		public TeacherRepository(ApplicationContext context)
		{
			this.context = context;
		}

		public void Add(Teacher teacher)
		{
			context.Teachers.Add(teacher);
			context.SaveChanges();
		}

        public IEnumerable<Teacher> GetTeachersWithSubject(string subject)
        {
            var extractedTeachers = context.Teachers.Where(teacher
				=> teacher.SubjectName == subject);

            return extractedTeachers;
        }

        public Subject ExtractTeacherSubject(string teacherId)
		{
			var teacherEntity = context.Teachers.FirstOrDefault(
				entity => entity.Id == teacherId);

            if (teacherEntity == null)
                throw new Exception("Invalid teacher_Id!");
            return teacherEntity.Subject;
		}
    }
}

