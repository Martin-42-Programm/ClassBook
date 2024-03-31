using System;
namespace ClassBook.Tests.Repository
{
	public class ClassRepositoryTest
	{
        private ClassRepository classRepository;
        private ApplicationContext applicationContext;


        [SetUp]
        public void SetUp()
        {
            applicationContext = SetUpApplicationContext();

            classRepository = new ClassRepository(applicationContext);

        }

        [TearDown]
        public void TearDown()
        {
            applicationContext.Database.EnsureDeleted();
        }


        [Test]
        public void GivenClass_WhenAddClass_AddClass()
        {
           
            var Class = new Class("11s");
           

            classRepository.Add(Class);

            var createdClass = applicationContext.Classes.LastOrDefault();


            Assert.AreEqual(Class, createdClass, "Classes are not the same");


               

        }

        [Test]
        public void Delete_WhenCalledWithClass_RemovesClassFromDatabase()
        {
            var classToRemove = new Class("11s");
            applicationContext.Classes.Add(classToRemove);
            applicationContext.SaveChanges();

            classRepository.Delete(classToRemove);
            var classInDb = applicationContext.Classes.Find(classToRemove.Id);

            Assert.IsNull(classInDb, "Class should have been removed.");
        }

        [Test]
        public void List_WhenCalled_ReturnsAllClasses()
        {
            var class1 = new Class("10s");
            var class2 = new Class("11s");
            applicationContext.Classes.AddRange(class1, class2);
            applicationContext.SaveChanges();

            var classes = classRepository.List();

            Assert.AreEqual(2, classes.Count);
            CollectionAssert.Contains(classes, class1);
            CollectionAssert.Contains(classes, class2);
        }


        [Test]
        public void GetClassByName_WhenCalledWithClassName_ReturnsClass()
        {
            var className = "11s";
            var expectedClass = new Class(className);
            applicationContext.Classes.Add(expectedClass);
            applicationContext.SaveChanges();

            var resultClass = classRepository.GetClassByName(className);

            Assert.IsNotNull(resultClass, "Class should not be null.");
            Assert.AreEqual(expectedClass.Id, resultClass.Id, "Class should match the expected class.");
        }




        private ApplicationContext SetUpApplicationContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase("UnitTestsDb");
            return new ApplicationContext(options.Options);
        }
    }


}


