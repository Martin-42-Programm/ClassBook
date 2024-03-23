using System;
using ClassBook.Repository.Interfaces;

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

		public void Delete(Class Class)
		{
			context.Classes.Remove(Class);
			context.SaveChanges();
		}

		public void Add(Class Class)
		{
			context.Classes.Add(Class);
			context.SaveChanges();
		}

        public Class GetClassByName(string className)
        {
            var classEntity = context.Classes.FirstOrDefault(entity => entity.Id == className);
			if (classEntity == null)
				throw new InvalidDataException("The class doesn't exist!");

            return classEntity;
        }
    }
}

