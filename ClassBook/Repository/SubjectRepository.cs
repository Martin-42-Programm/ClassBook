using System;
namespace ClassBook.Repository
{
	public class SubjectRepository : ISubjectRepository
	{
        private ApplicationContext context;

        public SubjectRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public List<Subject> List()
        {
            var list = context.Subjects.OrderBy(name => name.Name).ToList();
            return list;
        }

        public void Delete(Subject subject)
        {
            context.Subjects.Remove(subject);
            context.SaveChanges();
        }

        public void Add(Subject subject)
        {
            context.Subjects.Add(subject);
            context.SaveChanges();
        }

        public Subject GetSubjectById(string subject)
        {
            var subjectEntity = context.Subjects.FirstOrDefault(
                entity => entity.Name == subject);

            if (subjectEntity == null)
                throw new InvalidDataException("The subject doesn't exist!");

            return subjectEntity;
        }

    }
}

