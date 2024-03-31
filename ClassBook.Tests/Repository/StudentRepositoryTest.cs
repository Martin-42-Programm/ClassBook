using System;
using ClassBook.Data.Entities;

namespace ClassBook.Tests.Repository
{
	public class StudentRepositoryTest
	{
        private StudentRepository studentRepository;
        private ApplicationContext applicationContext;


        [SetUp]
        public void SetUp()
        {
            applicationContext = SetUpApplicationContext();

            studentRepository = new StudentRepository(applicationContext);

        }

        [TearDown]
        public void TearDown()
        {
            applicationContext.Database.EnsureDeleted();
        }

        [Test]
        public void GetAll_WhenCalled_ReturnsAllStudents()
        {
           // var Class = "11d";
            
            var students = new List<Student>
    {
        new Student("123", 19, "Martin", "Ivanov", "11d"),
        new Student("234", 12, "Valentin", "Chulev", "12s")
    };
            applicationContext.Students.AddRange(students);
            applicationContext.SaveChanges();

            var result = studentRepository.GetAll();

            CollectionAssert.AreEqual(students, result);
        }

        [Test]
        public void GetById_WhenCalledWithId_ReturnsStudent()
        {
            var studentId = "wdqib";
            var student = new Student(studentId, 12, "Valentin", "Chulev", "12s");
            applicationContext.Students.Add(student);
            applicationContext.SaveChanges();

            var result = studentRepository.GetById(studentId);

            Assert.AreEqual(student, result);
        }


        [Test]
        public void ExtractStudentsFromClass_WhenCalledWithClassName_ReturnsStudentsInClass()
        {
            var Class = "11e";
            var students = new List<Student>
            {
        new Student("123", 12, "Valentin", "Chulev", Class),
        new Student("124", 14, "Martin", "Ivanov", Class)
    };
            applicationContext.Students.AddRange(students);
            applicationContext.SaveChanges();

            var result = studentRepository.ExtractStudentsFromClass(Class);

            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.All(s => s.ClassId == Class));
        }


        [Test]
        public void GetStudentId_WhenCalledWithNumberInClassAndClass_ReturnsStudentId()
        {
            var student = new Student("124", 14, "Martin", "Ivanov", "11d");
            applicationContext.Students.Add(student);
            applicationContext.SaveChanges();

            var result = studentRepository.GetStudentId(14, "11d");

            Assert.AreEqual("124", result);
        }

        [Test]
        public void GetStudentsWithClass_WhenCalledWithClass_ReturnsStudentsInClass()
        {
            var students = new List<Student>
    {
         new Student("123", 12, "Valentin", "Chulev", "11d"),
        new Student("124", 14, "Martin", "Ivanov", "11d")
    };
            applicationContext.Students.AddRange(students);
            applicationContext.SaveChanges();

            var result = studentRepository.GetStudentsWithClass("11d");

            Assert.IsTrue(result.All(s => s.ClassId == "11d"));
        }

        [Test]
        public void Add_WhenCalledWithStudent_AddsStudentToDatabase()
        {
            var student = new Student("124", 14, "Martin", "Ivanov", "11d");

            studentRepository.Add(student);

            var addedStudent = applicationContext.Students.Find(student.Id);
            Assert.AreEqual(student, addedStudent);
        }



        private ApplicationContext SetUpApplicationContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase("UnitTestsDb");
            return new ApplicationContext(options.Options);
        }
    }


}


