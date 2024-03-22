using System;
using ClassBook.Data;
using ClassBook.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public List<Student> ExtractStudentsFromClass(string className)
        {
            var extractedStudents = Context.Students
                                            .Where(student => student.ClassId == className)
                                            .ToList();
            return extractedStudents;
        }

        public string GetStudentId(int numberInClass, string Class)
		{
			var student = Context.Students.FirstOrDefault(
						student => student.NumberInClass == numberInClass &&
									student.ClassId == Class);
			
			return student.Id;

		}

        public IEnumerable<Student> GetStudentsWithClass(string Class)
        {
			var extractedStudents = Context.Students.Where(student =>
									student.ClassId == Class).ToList();

            return extractedStudents;
        }

    }
}

