using System;
namespace ClassBook.Repository
{
	public class ClassRepository : IClassRepository
	{
		private ApplicationContext context;



		public ClassRepository(ApplicationContext context)
		{
			this.context = context;
		}

        public List<Class> List()
		{
			var list = context.Classes.OrderBy(name => name.Id).ToList();
			return list;
		}


    }
}

