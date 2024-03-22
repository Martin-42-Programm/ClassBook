using System;
namespace ClassBook.Tests.Services
{
	public class GradeServiceTest
	{

		private readonly GradeService gradeService;
        private IStudentService studentService;


        private Mock<IGradeRepository> gradeRepositoryMock;

		public GradeServiceTest()
		{
			gradeRepositoryMock = SerUpGradeRepositoryMock();
			gradeService = new GradeService(gradeRepositoryMock.Object, studentService);
		}


		[Test]
		public void GivenGrade_WhenAddingGrade_AddGrade()
		{
			var subject = new Subject("Maths");
			var student = new Student(13, "Martin", "Ivanov", "11d");
			var grade = new CreateGradeViewModel(student, "11s", 3.5, subject);

			gradeService.Add(grade);

			gradeRepositoryMock.Verify(
				mock => mock.Add(It.Is<Grade>(gradeEntity => 
					gradeEntity.StudentId == student.Id &&
					gradeEntity.Note == grade.Grade )),
				Times.Once);

		}




		private Mock<IGradeRepository> SerUpGradeRepositoryMock()
		{
			var gradeRepositoryMock = new Mock<IGradeRepository>();

			return gradeRepositoryMock;
		}
	}
}

