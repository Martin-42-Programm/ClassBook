using System;
using ClassBook.Repository;

namespace ClassBook.Services
{
	public class SubjectService : ISubjectService
	{
        private  ISubjectRepository subjectRepository;

        public SubjectService(ISubjectRepository subjectRepository)
        {
            this.subjectRepository = subjectRepository;
        }

        public List<Subject> List()
        {
            var list = subjectRepository.List();
            return list;
        }

        public void Delete(Subject subject)
        {
            subjectRepository.Delete(subject);
        }

        public void Add(Subject subject)
        {
            subjectRepository.Add(subject);
        }

        public Subject GetSubjectById(string subject)
        {
            var subjectEntity = subjectRepository.GetSubjectById(subject);

            


            return subjectEntity;
        }

    }
}

