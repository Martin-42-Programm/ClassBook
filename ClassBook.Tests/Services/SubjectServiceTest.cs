using System;
using ClassBook.Services;

namespace ClassBook.Tests.Services
{
	public class SubjectServiceTest
	{
        private readonly SubjectService subjectService;

        private Mock<ISubjectRepository> subjectRepositoryMock;

        public SubjectServiceTest()
        {
            subjectRepositoryMock = SetUpGradeRepositoryMock();
            subjectService = new SubjectService(subjectRepositoryMock.Object);
        }


        [Test]
        public void ListingSubjects()
        {
            subjectService.List();

            subjectRepositoryMock.Verify(
                mock => mock.List(), Times.Once);

        }

        [Test]
        public void GivenSubjectId_ReturnWholeSubjectEntity()
        {
            var Subject = new Data.Entities.Subject("11d");

            subjectService.GetSubjectById(Subject.Name);

            subjectRepositoryMock.Verify(
                mock => mock.GetSubjectById(Subject.Name), Times.Once());
        }

        [Test]
        public void GivenId_WhenAddClass_AddsClass()
        {
            var Subject = new Subject("Maths");
            subjectService.Add(Subject.Name);
            subjectRepositoryMock.Verify(
                mock => mock.Add(It.Is<Subject>(c => c.Name == Subject.Name)), Times.Once);

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





        private Mock<ISubjectRepository> SetUpGradeRepositoryMock()
        {
            var subjectRepositoryMock = new Mock<ISubjectRepository>();

            return subjectRepositoryMock;
        }
    }
}

