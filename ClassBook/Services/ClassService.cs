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

			var length = newClass.Id.Length;
			char lastChar = 'Z';
			int numberOfClass = 0;
			if (length == 3)
			{
				lastChar = newClass.Id[2];
				numberOfClass = int.Parse(newClass.Id.Substring(0, 2));
			}
			else if (length == 2)
			{
				lastChar = newClass.Id[1];
				numberOfClass = int.Parse(newClass.Id.Substring(0, 1));
			}


			if (!doesAlreadyExist)
				if (numberOfClass >= 1 && numberOfClass <= 12 && lastChar >= 'a' && lastChar <= 'z')
					classRepository.Add(newClass);
				
		}

		public Class GetClassByName(string className)
		{
			var classEntity = classRepository.GetClassByName(className);
			return classEntity;
		}
		
	}
}

