using System;
namespace ClassBook.Repository
{
	public class GradeRepository : IGradeRepository
	{
		public Data.ApplicationContext context;

		public GradeRepository(Data.ApplicationContext context)
		{
			this.context = context;
		}


		public Grade Get(int id)
			=> context.Grades.FirstOrDefault(grade => grade.Id == id);
		


		public void Add(Grade grade)
		{
			context.Grades.Add(grade);
			context.SaveChanges();
		}

		public void Delete(int id)
		{
			var entity = Get(id);
			context.Grades.Remove(entity);
			context.SaveChanges();
		}

		
	}
}

