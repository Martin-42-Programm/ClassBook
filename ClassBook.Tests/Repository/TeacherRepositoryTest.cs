using System;
using ClassBook.Data.Entities;

namespace ClassBook.Tests.Repository
{
	public class TeacherRepositoryTest
	{
        private TeacherRepository teacherRepository;
        private ApplicationContext applicationContext;


        [SetUp]
        public void SetUp()
        {
            applicationContext = SetUpApplicationContext();

            teacherRepository = new TeacherRepository(applicationContext);

        }

        [TearDown]
        public void TearDown()
        {
            applicationContext.Database.EnsureDeleted();
        }

        [Test]
        public void Add_WhenCalledWithTeacher_AddsTeacherToDatabase()
        {
            var subject = new Subject("Bio");
            var teacherToAdd = new Teacher ("123", "Stoyan", "Ivaov", subject);

            teacherRepository.Add(teacherToAdd);

            var addedTeacher = applicationContext.Teachers.FirstOrDefault(t => t.Id == teacherToAdd.Id);
            Assert.IsNotNull(addedTeacher);
            Assert.AreEqual(teacherToAdd.Name, addedTeacher.Name);
            
        }

        [Test]
        public void GetTeachersWithSubject_WhenCalledWithSubject_ReturnsTeachersWithThatSubject()
        {
            var subjectName = new Subject("Mathematics");
            var subjectFalse = new Subject("Bio");
            var teacher1 = new Teacher("123", "Stoyan", "Ivaov", subjectName);
            var teacher2 = new Teacher("124", "Stoyan", "Ivaov", subjectFalse); ;
            applicationContext.Teachers.AddRange(teacher1, teacher2);
            applicationContext.SaveChanges();

            var result = teacherRepository.GetTeachersWithSubject(subjectName.Name);

            Assert.IsTrue(result.Any());
            Assert.IsTrue(result.All(t => t.SubjectName == subjectName.Name));
        }

        [Test]
        public void ExtractTeacherSubject_WhenCalledWithValidTeacherId_ReturnsSubject()
        {
            var teacherId = "teacher1";
            var teacherSubject = new Subject("Mathematics");
            var teacher =  new Teacher(teacherId, "Stoyan", "Ivaov", teacherSubject); ;
            applicationContext.Teachers.Add(teacher);
            applicationContext.SaveChanges();

            var result = teacherRepository.ExtractTeacherSubject(teacherId);

            Assert.IsNotNull(result);
            Assert.AreEqual(teacherSubject.Name, result.Name);
        }

        [Test]
        public void ExtractTeacherSubject_WhenCalledWithInvalidTeacherId_ThrowsException()
        {
            var invalidTeacherId = "invalidTeacherId";

            Assert.Throws<Exception>(() => teacherRepository.ExtractTeacherSubject(invalidTeacherId));
        }



        private ApplicationContext SetUpApplicationContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase("UnitTestsDb");
            return new ApplicationContext(options.Options);
        }
    }
}

