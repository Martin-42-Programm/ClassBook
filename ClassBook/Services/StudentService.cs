using System;
using ClassBook.Repository;
using ClassBook.Repository.Interfaces;
using ClassBook.Services.Interfaces;

namespace ClassBook.Services
{
	public class StudentService : IStudentService
	{

		private IStudentRepository studentRepository;


		public StudentService(IStudentRepository studentRepository)
		{
			this.studentRepository = studentRepository;
		}

		public IEnumerable<Student> GetAll()
		{
            var studentEntities = studentRepository.GetAll();

           
            return studentEntities;
        }

		public Student GetById(int id)
		{
			var student = studentRepository.GetById(id);

			return student;
		}

        public List<Student> CreateAListOfStudents(string className)
        {
            var newListOfStudents = studentRepository
											.ExtractStudentsFromClass(className);
            return newListOfStudents;
        }

        public string GetStudentId(int numberInClass, string Class)
		{
			var studentId = studentRepository.GetStudentId(numberInClass, Class);

			return studentId;
		}

		public IEnumerable<Student> GetStudentsWithClass(string Class)
		{
			var extractedStudents = studentRepository.GetStudentsWithClass(Class);

			return extractedStudents;
		}
    }
}

