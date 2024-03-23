using System;
using ClassBook.Repository;
using ClassBook.Repository.Interfaces;

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

        public void Delete(string subject)
        {
            var newSubject = new Subject(subject);
            bool doesAlreadyExist = false;

            var compareClass = subjectRepository.GetSubjectById(subject);
            if (compareClass != null)
                doesAlreadyExist = true;

            if (doesAlreadyExist)
                subjectRepository.Delete(newSubject);
        }

        public void Add(string subject)
        {

            var newSubject = new Subject(subject);
            bool doesAlreadyExist = false;

            var compareSubject = subjectRepository.GetSubjectById(subject);
            if (compareSubject != null)
                doesAlreadyExist = true;

            if (!doesAlreadyExist)
                subjectRepository.Add(newSubject);
            
        }

        public Subject GetSubjectById(string subject)
        {
            var subjectEntity = subjectRepository.GetSubjectById(subject);

            


            return subjectEntity;
        }

    }
}

