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

		public void Delete(Class Class)
		{
			classRepository.Delete(Class);
		}

		public void Add(Class Class)
		{
			classRepository.Add(Class);
		}

		public Class GetClassByName(string className)
		{
			var classEntity = classRepository.GetClassByName(className);
			return classEntity;
		}
		
	}
}

