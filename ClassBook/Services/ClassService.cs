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


		public List<Class> List()
		{
			var list = classRepository.List();
			return list;
		}
		
	}
}

