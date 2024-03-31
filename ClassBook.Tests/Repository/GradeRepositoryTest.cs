using System;
using Microsoft.EntityFrameworkCore;

namespace ClassBook.Tests.Repository
{
	public class GradeRepositoryTest
	{
		private GradeRepository gradeRepository;
		private ApplicationContext applicationContext;


		[SetUp]
		public void SetUp()
		{
			applicationContext = SetUpApplicationContext();

			gradeRepository = new GradeRepository(applicationContext);

		}

		[TearDown]
		public void TearDown()
		{
			applicationContext.Database.EnsureDeleted();
		}

      
        [Test]
		public void GivenGrade_WhenAddGrade_AddGrade()
		{
			var subject = new Subject("24");
			var Class = new Class("11s");
            var student = new Student("df", 13, "Martin", "Ivanov", Class);
            var grade = new Grade(4.8, subject, student);

			gradeRepository.Add(grade);

			var createdGrade = applicationContext.Grades.LastOrDefault();

			
			Assert.AreEqual(grade, grade, "Different Grade than expected!");

        }

        [Test]
        public void Get_WhenCalledWithId_ReturnsGrade()
        {
			var student = new Student("123", 12, "Martin", "Ivanov", "11d");
			var subject = new Subject("Bio");
			var grade = new Grade(2,subject, student);
            applicationContext.Grades.Add(grade);
            applicationContext.SaveChanges();

            var result = gradeRepository.Get(1);

            Assert.AreEqual(grade, result);
        }

        [Test]
        public void Add_WhenCalledWithGrade_AddsGradeToDatabase()
        {
            var student = new Student("123", 12, "Martin", "Ivanov", "11d");
            var subject = new Subject("Bio");
            var grade = new Grade(2, subject, student);

            gradeRepository.Add(grade);

            var addedGrade = applicationContext.Grades.Find(grade.Id);
            Assert.AreEqual(grade, addedGrade);
        }

        [Test]
        public void Delete_WhenCalledWithId_DeletesGradeFromDatabase()
        {
            var student = new Student("123", 12, "Martin", "Ivanov", "11d");
            var subject = new Subject("Bio");
            var grade = new Grade(2, subject, student);
            applicationContext.Grades.Add(grade);
            applicationContext.SaveChanges();

            gradeRepository.Delete(1);

            var deletedGrade = applicationContext.Grades.Find(1);
            Assert.IsNull(deletedGrade);
        }

        [Test]
        public void GetAllByStudentIdAndSubjectId_WhenCalledWithIds_ReturnsGrades()
        {
            var studentId = "student1";
            var subjectName = "Math";
            var student = new Student(studentId, 12, "Martin", "Ivanov", "11d");
            var subject = new Subject(subjectName);
            
            var grades = new List<Grade>
    {
        new Grade (2, subject, student),
        new Grade (3, subject, student)
    };
            applicationContext.Grades.AddRange(grades);
            applicationContext.SaveChanges();

            var result = gradeRepository.GetAllByStudentIdAndSubjectId(studentId, subjectName);

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(subjectName, result.First().SubjectName);
        }

        [Test]
        public void GetAll_WhenCalledWithId_ReturnsGradeViewModels()
        {
            var studentId = "student1";
            var student = new Student(studentId, 12, "Martin", "Ivanov", "11d");
            var subject = new Subject("Bio");
            var grade = new Grade(2, subject, student);
            applicationContext.Students.Add(student);
            applicationContext.Subjects.Add(subject);
            applicationContext.Grades.Add(grade);
            applicationContext.SaveChanges();

            var result = gradeRepository.GetAll(studentId);

            Assert.AreEqual(1, result.Count());
            var viewModel = result.First();
            Assert.AreEqual(subject.Name, viewModel.Subject);
            Assert.AreEqual(student.NumberInClass, viewModel.NumberInClass);
            Assert.AreEqual(1, viewModel.GradesInCertainSubject.Count);
        }



        private ApplicationContext SetUpApplicationContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationContext>()
				.UseInMemoryDatabase("UnitTestsDb");
			return new ApplicationContext(options.Options);
		}
	}


}

