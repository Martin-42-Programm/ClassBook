using System;
namespace ClassBook.Services
{
	public class ClassService : IClassService
	{
		private IClassRepository classRepository;



		public ClassService(IClassRepository classRepository)
		{
			this.classRepository = classRepository;
		}

		
	}
}

