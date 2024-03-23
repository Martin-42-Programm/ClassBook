using System;
using ClassBook.Data.Entities;
using ClassBook.Repository.Interfaces;

namespace ClassBook.Repository
{
	public class GradeRepository : IGradeRepository
	{
		public ApplicationContext context;

		public GradeRepository(ApplicationContext context)
		{
			this.context = context;
		}


		public Grade Get(int id)
			=> context.Grades.FirstOrDefault(grade => grade.Id == id);



		public void Add(Grade grade)
		{
			context.Grades.Add(grade);
			context.SaveChanges();
		}

		public void Delete(int id)
		{
			var entity = Get(id);
			context.Grades.Remove(entity);
			context.SaveChanges();
		}

        public ICollection<Grade> GetAllByStudentIdAndSubjectId(string studentId, string subjectName)
		{
			var entities = context.Grades.Where(
				grade => grade.StudentId == studentId && grade.SubjectName == subjectName)
				.ToList();
			return entities;
		}



        public IEnumerable<GradeViewModel> GetAll(string id)
        {
            var list = new List<GradeViewModel>();
			
			var student = context.Students.FirstOrDefault(student => student.Id == id) ??
				throw new InvalidDataException("Student is null!");
			var grades = context.Grades.Where(grade => grade.StudentId == id).ToList();
			

            foreach (var subject in context.Subjects)
            {
				list.Add(new GradeViewModel(
					student,
					subject.Name.ToString(),
					grades.Where(special => special.SubjectName == subject.Name).ToList()

					)) ;

            }

			

			return list;
        }

        
    }
}

