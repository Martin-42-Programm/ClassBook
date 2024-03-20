using System;
using ClassBook.Data;

namespace ClassBook.Repository
{
	public class StudentRepository : IStudentRepository
	{
		private ApplicationContext Context;


		public StudentRepository(ApplicationContext context)
		{
			this.Context = context;
		}

		public IEnumerable<Student> GetAll()
		{
			return Context.Students.ToList();
		}

		public Student GetById(int id)
		{
			var student = Context.Students.FirstOrDefault(student => student.NumberInClass == id);
			return student;
		}

	}
}

