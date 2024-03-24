using System;
using ClassBook.Data.Entities;

namespace ClassBook.Tests.Services
{
	public class StudentServiceTest
	{
        private StudentService StudentService;
        private Mock<IStudentService> StudentServiceMock;
        private Mock<IStudentRepository> StudentRepositoryMock;
        private Mock<IClassService> classServiceMock;
        private Mock<ApplicationContext> context;


        public StudentServiceTest(IClassService classServiceMock)
        {
            StudentRepositoryMock = SetUpGradeRepositoryMock();
            this.classServiceMock = new Mock<IClassService>();
            StudentServiceMock = new Mock<IStudentService>();
            context = new Mock<ApplicationContext>();
            StudentService = new StudentService(StudentRepositoryMock.Object, classServiceMock);
        }
        public StudentServiceTest()
        {
            StudentRepositoryMock = SetUpGradeRepositoryMock();
            this.classServiceMock = new Mock<IClassService>();
            StudentServiceMock = new Mock<IStudentService>();
            StudentService = new StudentService(StudentRepositoryMock.Object, this.classServiceMock.Object);
        }


        [Test]
        public void GetAll_WhenCalled_ReturnsAllStudents()
        {
            var Class = new Class("11d");
            var expectedStudents = new List<Student> { new Student("qwe",12, "Martin", "Ivanov", Class ),
                                                        new Student("qwer",13, "Mart", "Petrov", Class )};
            
            StudentRepositoryMock.Setup(repo => repo.GetAll()).Returns(expectedStudents);
            //var studentService = new StudentService(StudentRepositoryMock.Object, classService);

           
            var result = StudentService.GetAll();

          
            StudentRepositoryMock.Verify(
                mock => mock.GetAll(), Times.Once);
        }


        [Test]
        public void GetById_WhenCalledWithId_ReturnsStudent()
        {
            // Arrange
            var Class = new Class("11d");
            var studentId = "student1";
            var expectedStudent = new Student("qws", 11, "Mitko", "Stanev", Class);
            //var studentRepositoryMock = new Mock<IStudentRepository>();
            StudentRepositoryMock.Setup(repo => repo.GetById(studentId)).Returns(expectedStudent);
            //var studentService = new StudentService(studentRepositoryMock.Object);

            // Act
            var result = StudentService.GetById(studentId);

            // Assert
            Assert.AreEqual(expectedStudent, result);
        }

        [Test]
        public void CreateAListOfStudents_WhenCalledWithClassName_ReturnsStudentsList()
        {
            var className = "11d";
            
            var result = StudentService.CreateAListOfStudents(className);
            StudentRepositoryMock.Verify(
                mock => mock.ExtractStudentsFromClass(It.Is<string>(c => c == className)), Times.Once);
            
        }

        [Test]
        public void GetStudentId_WhenCalledWithNumberInClassAndClass_ReturnsStudentId()
        {
            // Arrange
            var numberInClass = 1;
            var expectedStudentId = "student1";
            var className = "ClassA";
            var Class = new Class(className);
            var student = new CreateStudentViewModel(expectedStudentId, "Martin", numberInClass,  "Ivanov", className);

            //this.StudentService.Add(student);
            // Setup the necessary logic or mock if needed
            //var studentService = new StudentService(/* ... dependencies ... */);

            // Act
            var result =StudentService.GetStudentId(numberInClass, className);

            StudentRepositoryMock.Verify(
                mock => mock.GetStudentId(It.Is<int>(a => a == numberInClass), It.Is<string>(a => a == className)), Times.Once);

        }

        [Test]
        public void GetStudentsWithClass_WhenCalledWithClass_ReturnsStudents()
        {
            // Arrange
            var className = "ClassA";
            var Class = new Class(className);
            var expectedStudents = new List<Student> { new Student("qwe",12, "Martin", "Ivanov", Class ),
                                                        new Student("qwer",13, "Mart", "Petrov", Class )};
            var studentRepositoryMock = new Mock<IStudentRepository>();
            studentRepositoryMock.Setup(repo => repo.GetStudentsWithClass(className)).Returns(expectedStudents);
            //var studentService = new StudentService(studentRepositoryMock.Object);

            // Act
            var result = StudentService.GetStudentsWithClass(className);

            StudentRepositoryMock.Verify(
                mock => mock.GetStudentsWithClass(It.Is<string>(a => a == className)), Times.Once);
        }


        [Test]
        public void Add_WhenCalledWithStudent_AddsStudent()
        {
            // Arrange
            var id = "qwe";
            var numberInClass = 3;
            var name = "Martin";
            var surname = "Ivanov";
            var className = "Bio";
            var Class = new Class(className);
            var studentViewModel = new CreateStudentViewModel(id, name, numberInClass, surname, className);
            var student = new Student(id, numberInClass, name, surname, Class);
            var studentRepositoryMock = new Mock<IStudentRepository>();
            var studentService = new StudentService(studentRepositoryMock.Object, classServiceMock.Object);

            // Act
            studentService.Add(studentViewModel);

            // Assert
            // Verify that the Add method was called on the repository
            StudentRepositoryMock.Verify(repo => repo.Add(It.IsAny<Student>()/*(stu => stu == student)*/), Times.Once);
        }






        private Mock<IStudentRepository> SetUpGradeRepositoryMock()
        {
            var StudentRepositoryMock = new Mock<IStudentRepository>();

            return StudentRepositoryMock;
        }
    }
}

