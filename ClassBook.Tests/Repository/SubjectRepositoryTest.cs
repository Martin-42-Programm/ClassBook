using System;
namespace ClassBook.Tests.Repository
{
	public class SubjectRepositoryTest
	{
        private SubjectRepository subjectRepository;
        private ApplicationContext applicationContext;


        [SetUp]
        public void SetUp()
        {
            applicationContext = SetUpApplicationContext();

            subjectRepository = new SubjectRepository(applicationContext);

        }

        [TearDown]
        public void TearDown()
        {
            applicationContext.Database.EnsureDeleted();
        }

        [Test]
        public void List_WhenCalled_ReturnsAllSubjectsOrderedByName()
        {
            var subjects = new List<Subject>
    {
        new Subject ("Mathematics"),
        new Subject ("Science")
    };
            applicationContext.Subjects.AddRange(subjects);
            applicationContext.SaveChanges();

            var result = subjectRepository.List();

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Mathematics", result[0].Name);
            Assert.AreEqual("Science", result[1].Name);
        }

        [Test]
        public void Delete_WhenCalledWithSubject_RemovesSubjectFromDatabase()
        {
            var subjectToDelete = new Subject ("Mathematics");
            applicationContext.Subjects.Add(subjectToDelete);
            applicationContext.SaveChanges();

            subjectRepository.Delete(subjectToDelete);

            var deletedSubject = applicationContext.Subjects.Find(subjectToDelete.Name);
            Assert.IsNull(deletedSubject);
        }

        [Test]
        public void Add_WhenCalledWithSubject_AddsSubjectToDatabase()
        {
            var subjectToAdd = new Subject { Name = "Mathematics" };

            subjectRepository.Add(subjectToAdd);

            var addedSubject = applicationContext.Subjects.FirstOrDefault(s => s.Name == subjectToAdd.Name);
            Assert.IsNotNull(addedSubject);
            Assert.AreEqual(subjectToAdd.Name, addedSubject.Name);
        }

        [Test]
        public void GetSubjectById_WhenCalledWithSubjectName_ReturnsSubject()
        {
            var subject = new Subject { Name = "Mathematics" };
            applicationContext.Subjects.Add(subject);
            applicationContext.SaveChanges();

            var result = subjectRepository.GetSubjectById("Mathematics");

            Assert.IsNotNull(result);
            Assert.AreEqual("Mathematics", result.Name);
        }



        private ApplicationContext SetUpApplicationContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase("UnitTestsDb");
            return new ApplicationContext(options.Options);
        }
    }
}

