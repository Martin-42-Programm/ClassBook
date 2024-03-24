using System;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace ClassBook.Tests.Services
{
	public class ClassServiceTest
	{
        private readonly ClassService classService;
        private IStudentService studentService;


        private Mock<IClassRepository> classRepositoryMock;

        public ClassServiceTest()
        {
            classRepositoryMock = SetUpGradeRepositoryMock();
            classService = new ClassService(classRepositoryMock.Object);
        }

       


        [Test]
        public void ListingClasses()
        {
            classService.List();

            classRepositoryMock.Verify(
                mock => mock.List(), Times.Once);

        }

        [Test]
        public void GivenClassId_ReturnWholeClassEntity()
        {
            var Class = new Data.Entities.Class("11d");
            
            classService.GetClassByName(Class.Id);
            classRepositoryMock.Verify(
                mock => mock.GetClassByName(Class.Id), Times.Once());
        }

        [Test]
        public void GivenId_WhenAddClass_AddsClass()
        {
            var Class = new Class("11d");
            classService.Add(Class.Id);
            classRepositoryMock.Verify(
                mock => mock.Add(It.Is<Class>(c => c.Id == Class.Id)), Times.Once);

        }

        /*[Test] //Doesn't work because of foreign keys.
        public void GivenId_WhenDeleteClass_DeletesClass()
        {
            var Class = new Class("11d");
            classRepositoryMock.Setup(mock => mock.GetClassByName(Class.Id)).Returns(Class);

            classService.Delete(Class.Id);

            classRepositoryMock.Verify(
                mock => mock.Delete(It.Is<Class>(c => c == Class)), Times.Once());
        }*/





        private Mock<IClassRepository> SetUpGradeRepositoryMock()
        {
            var classRepositoryMock = new Mock<IClassRepository>();

            return classRepositoryMock;
        }
    }
}

