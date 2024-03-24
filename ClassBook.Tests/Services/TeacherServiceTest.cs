using System;
namespace ClassBook.Tests.Services
{
	public class TeacherServiceTest
	{
        private TeacherService TeacherService;
        private Mock<ITeacherService> TeacherServiceMock;
        private Mock<ITeacherRepository> TeacherRepositoryMock;
        private Mock<ISubjectService> subjectServiceMock;

       

        public TeacherServiceTest()
        {
            TeacherRepositoryMock = SetUpGradeRepositoryMock();
            subjectServiceMock = new Mock<ISubjectService>();
            TeacherServiceMock = new Mock<ITeacherService>();
            TeacherService = new TeacherService(TeacherRepositoryMock.Object, subjectServiceMock.Object);
        }

        

        [Test]
        public void GivenTeacher_WhenAddTeacher_AddsTeacher()
        {

            subjectServiceMock.Setup(service => service.GetSubjectById("Bio"))
                      .Returns(new Subject { Name = "Bio" });
            var teacher = new CreateTeacherViewModel("dff", "Petar", "Ivanov", "Bio");
           
            TeacherService.Add(teacher);
            TeacherRepositoryMock.Verify(
                mock => mock.Add(It.Is<Teacher>(c => c.Id == teacher.Id &&
                                                      c.Name == teacher.Name &&
                                                      c.Surname == teacher.Surname &&
                                                      c.SubjectName == teacher.Subject)), Times.Once);

        }

        /*[Test]
        public void GivenSubject_WhenAddTeacher_ReturnsTeacherInThisSubject()
        {
            var subjectName = "German";
            var subject = new Subject(subjectName);
            var createTeacher = new CreateTeacherViewModel("q1", "Sasho", "Kulagin", subjectName);
            var teacher = new Teacher("q1", "Sasho", "Kulagin", subject);
            

            TeacherServiceMock.Setup(Services => Services.GetТeachersWithSubject("German"))
                .Returns(new List<Teacher> { teacher});
            TeacherService.Add(createTeacher);

            TeacherRepositoryMock.Verify(
                mock => mock.GetTeachersWithSubject(It.Is<string>(c => c == createTeacher.Subject)), Times.Once);

        }*/

        [Test]
        public void GetTeachersWithSubject_GivenSubject_ReturnsTeachersOfThatSubject()
        {
            // Arrange
            var subjectName = "Math";
            var expectedTeachers = new List<Teacher>
        {
            new Teacher("1", "John", "Doe", new Subject(subjectName)),
            new Teacher("2", "Jane", "Doe", new Subject(subjectName))
        };

            TeacherRepositoryMock.Setup(repo => repo.GetTeachersWithSubject(subjectName))
                                  .Returns(expectedTeachers);

            // Act
            var result = TeacherService.GetТeachersWithSubject(subjectName);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.IsTrue(result.All(t => t.Subject.Name == subjectName));
        }


        /*[Test]
        public void GivenTeacherId_WhenExtractTeacherSubject_ReturnsCorrectSubject()
        {
            // Arrange
            var teacherId = "teacher1";
            var expectedSubject = new Subject { Name = "Math" };
            var teacher = new Teacher(teacherId, "John", "Doe", expectedSubject);

            TeacherRepositoryMock.Setup(repo => repo.GetById(teacherId))
                                 .Returns(teacher);
            subjectServiceMock.Setup(service => service.GetSubjectByName(teacher.Subject.Name))
                              .Returns(expectedSubject);

            // Act
            var result = TeacherService.ExtractTeacherSubject(teacherId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedSubject.Name, result.Name);
        }
        */


        private Mock<ITeacherRepository> SetUpGradeRepositoryMock()
        {
            var TeacherRepositoryMock = new Mock<ITeacherRepository>();

            return TeacherRepositoryMock;
        }
    }
}

