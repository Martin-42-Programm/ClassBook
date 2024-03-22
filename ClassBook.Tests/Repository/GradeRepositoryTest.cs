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
            var student = new Student(13, "Martin", "Ivanov", "11d");
            var grade = new Grade(4.8, subject, student);

			gradeRepository.Add(grade);

			var createdGrade = applicationContext.Grades.LastOrDefault();

			
			Assert.AreEqual(grade, grade, "Different Grade than expected!");

        }


		private ApplicationContext SetUpApplicationContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationContext>()
				.UseInMemoryDatabase("UnitTestsDb");
			return new ApplicationContext(options.Options);
		}
	}


}

