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


		
	}
}

