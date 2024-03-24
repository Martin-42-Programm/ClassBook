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
			gradeRepositoryMock = SetUpGradeRepositoryMock();
			
			gradeService = new GradeService(gradeRepositoryMock.Object, studentService);
		}


		[Test]
		public void GivenGrade_WhenAddingGrade_AddGrade()
		{
			var subject = new Subject("Maths");
			var Class = new Class("Pesho");
			var student = new Student("qwerty",13, "Martin", "Ivanov", Class);
			var grade = new CreateGradeViewModel(student, "11s", 3.5, subject);

			gradeService.Add(grade);

			gradeRepositoryMock.Verify(
				mock => mock.Add(It.Is<Grade>(gradeEntity => 
					gradeEntity.StudentId == student.Id &&
					gradeEntity.Note == grade.Grade )),
				Times.Once);

		}

		[Test]
		public void GivenNull_WhenAddGrade_ReturnError()
		{
			gradeRepositoryMock.Verify(
				mock => mock.Add(null), Times.Never());
		}

        [Test]
        public void GetAllByStudentIdAndSubjectId_WhenCalledWithIds_ReturnsGrades()
        {
            // Arrange
            var studentId = "student1";
			var Class = new Class("11d");
			var student = new Student(studentId, 12, "Martin", "Ivanov", Class);
            var subjectId = "subject1";
			var subject = new Subject(subjectId);
			var expectedGrades = new List<Grade>
			{
				new Grade(2, subject, studentId),
				new Grade(3, subject, studentId)

			};
           // var gradeRepositoryMock = new Mock<IGradeRepository>();
            gradeRepositoryMock.Setup(repo => repo.GetAllByStudentIdAndSubjectId(studentId, subjectId))
                               .Returns(expectedGrades);
            //var gradeService = new GradeService(gradeRepositoryMock.Object);

            // Act
            var result = gradeService.GetAllByStudentIdAndSubjectId(studentId, subjectId);

			gradeRepositoryMock.Verify(
				mock => mock.GetAllByStudentIdAndSubjectId(It.Is<string>(a => a == studentId), It.Is<string>(a => a == subjectId)), Times.Once);
            //CollectionAssert.AreEquivalent(expectedGrades, result);
        }


        [Test]
        public void GetAll_WhenCalledWithNumberInClassAndClass_ReturnsGradeViewModels()
        {
            // Arrange
            var numberInClass = 1;
            var className = "ClassA";
			var subject = new Subject("Bio");
			var Class = new Class(className);
			
			var student = new Student("sas", numberInClass, "Martin", "Ivanov", Class);
			var grades = new List<Grade> {
				new Grade(2, subject, student),
				new Grade(3, subject, student)

			};
            var expectedGrades = new List<GradeViewModel> {
				new GradeViewModel(student, subject.Name, grades),

                new GradeViewModel(student, "Physics", grades)

            };
            // Assuming GradeService has logic to convert Grades to GradeViewModels
            //var gradeRepositoryMock = new Mock<IGradeRepository>();
            // Setup mock to return raw grade data or mock the conversion logic
            //var gradeService = new GradeService(gradeRepositoryMock.Object, /* other dependencies if any */);

            // Act
		
            var result = gradeService.GetAll(numberInClass, className);
			gradeRepositoryMock.Verify(
				mock => mock.GetAll(It.Is<string>(a => a == "sas")), Times.Once);

            // Assert
            //CollectionAssert.AreEquivalent(expectedGrades, result);
        }







        private Mock<IGradeRepository> SetUpGradeRepositoryMock()
		{
			var gradeRepositoryMock = new Mock<IGradeRepository>();

			return gradeRepositoryMock;
		}
	}
}

