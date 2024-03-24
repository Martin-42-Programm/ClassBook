using System;
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
		public void GivenNull_WhenAddGrade_ReturnError()
		{
			gradeRepository.Add(null);

			var createdGrade = applicationContext.Grades.LastOrDefault();

			Assert.Null(createdGrade, "Null object was assigned!");
		}




		private ApplicationContext SetUpApplicationContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationContext>()
				.UseInMemoryDatabase("UnitTestsDb");
			return new ApplicationContext(options.Options);
		}
	}


}

