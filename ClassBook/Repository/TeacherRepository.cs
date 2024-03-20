using System;
namespace ClassBook.Repository
{
	public class TeacherRepository
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
	}
}

