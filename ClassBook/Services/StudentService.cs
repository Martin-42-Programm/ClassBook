using System;
using ClassBook.Repository;
using ClassBook.Services.Interfaces;

namespace ClassBook.Services
{
	public class StudentService : IStudentService
	{

		private IStudentRepository Repository;


		public StudentService(IStudentRepository repository)
		{
			this.Repository = repository;
		}

		public IEnumerable<Student> GetAll()
		{
            var studentEntities = Repository.GetAll();

           
            return studentEntities;
        }

		public Student GetById(int id)
		{
			var student = Repository.GetById(id);

			return student;
		}
	}
}

