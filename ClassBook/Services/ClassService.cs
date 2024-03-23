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

		public void Delete(string Class)
		{
			var newClass = new Class(Class);
            bool doesAlreadyExist = false;
            var compareClass = classRepository.GetClassByName(Class);

            if (compareClass != null)
                doesAlreadyExist = true;

			if (doesAlreadyExist)
				classRepository.Delete(newClass);
			else
				throw new Exception("Not an existing entity!");
		}

		public void Add(string Class)
		{
			var newClass = new Class(Class);
			bool doesAlreadyExist = false;

			var compareClass = classRepository.GetClassByName(Class);
			if (compareClass != null)
				doesAlreadyExist = true;
				
			if (!doesAlreadyExist)
				classRepository.Add(newClass);
		}

		public Class GetClassByName(string className)
		{
			var classEntity = classRepository.GetClassByName(className);
			return classEntity;
		}
		
	}
}

