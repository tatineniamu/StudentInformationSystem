using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.DataBase;
using StudentInformationSystem.DataBase.Entities;
using StudentInformationSystem.Pages.Student;
using StudentInformationSystem.Repository;
using System;
using System.Threading.Tasks;
using Xunit;

namespace UnitTestSIS
{
    public class StudentDetailsUnitTest
    {
        private IStudentDetailsRepository GetInMemoryStudentRepository()
        {
            DbContextOptions<DataContext> options;
            var builder = new DbContextOptionsBuilder<DataContext>();
            builder.UseInMemoryDatabase("SIS");
            options = builder.Options;
            DataContext sisDataContext = new DataContext(options);
            sisDataContext.Database.EnsureDeleted();
            sisDataContext.Database.EnsureCreated();
            return new StudentDetailsRepository(sisDataContext);
        }

        [Fact]
        public async Task Add_Student_Should_Work()
        {
            //arrange
            var studentRepo = GetInMemoryStudentRepository();
            var studentObj = new StudentDetails()
            {
                Id = 1,
                StudentId = "A1234567",
                FirstName = "Test FName",
                LastName = "Test LName",
                //AddressId = 1,
                Address = new Address()
                {
                    Address1 = "Sample st",
                    City = "Sample City",
                    StateName = "NY",
                    Country = "USA",
                    ZipCode = "12345"
                }
            };

            //act
            await studentRepo.AddAsync(studentObj);
            var studentDetail = await studentRepo.GetById(1);

            //assert
            Assert.NotNull(studentDetail);
            Assert.Equal(studentObj.FirstName, studentDetail.FirstName);
            Assert.Equal(studentObj.Address.Address1, studentDetail.Address.Address1);
        }

        [Fact]
        public async Task Edit_Student_Should_Work()
        {
            //arrange
            var studentRepo = GetInMemoryStudentRepository();
            var studentObj = new StudentDetails()
            {
                Id = 1,
                StudentId = "A1234567",
                FirstName = "Test FName",
                LastName = "Test LName",
                //AddressId = 1,
                Address = new Address()
                {
                    Address1 = "Sample st",
                    City = "Sample City",
                    StateName = "NY",
                    Country = "USA",
                    ZipCode = "12345"
                }
            };

            //act
            await studentRepo.AddAsync(studentObj);
            var studentDetail = await studentRepo.GetById(1);
            
            //now update the details
            studentDetail.FirstName = "Updated FName";
            studentDetail.Address.Address1 = "Updated Sample st";
            await studentRepo.UpdateAsync(studentDetail);

            //again retrive the details
            var updatedStudentDetail = await studentRepo.GetById(1);

            //assert
            Assert.Equal("Updated FName", updatedStudentDetail.FirstName);
            Assert.Equal("Updated Sample st", updatedStudentDetail.Address.Address1);
        }

        [Fact]
        public async Task Delete_Student_Should_Work() {
            //arrange
            var studentRepo = GetInMemoryStudentRepository();
            var studentObj = new StudentDetails()
            {
                Id = 1,
                StudentId = "A1234567",
                FirstName = "Test FName",
                LastName = "Test LName",
                //AddressId = 1,
                Address = new Address()
                {
                    Address1 = "Sample st",
                    City = "Sample City",
                    StateName = "NY",
                    Country = "USA",
                    ZipCode = "12345"
                }
            };

            //act
            await studentRepo.AddAsync(studentObj);
            await studentRepo.DeleteAsync(studentObj);
            var studentList = await studentRepo.GetAllAsync();

            //assert
            Assert.Empty(studentList);
        }

        [Fact]
        public async Task View_Student_Should_Work() {
            //arrange
            var studentRepo = GetInMemoryStudentRepository();
            var studentObj = new StudentDetails()
            {
                Id = 1,
                StudentId = "A1234567",
                FirstName = "Test FName",
                LastName = "Test LName",
                //AddressId = 1,
                Address = new Address()
                {
                    Address1 = "Sample st",
                    City = "Sample City",
                    StateName = "NY",
                    Country = "USA",
                    ZipCode = "12345"
                }
            };

            //act
            await studentRepo.AddAsync(studentObj);
            var studentDetail = await studentRepo.GetById(1);

            //assert
            Assert.NotNull(studentDetail);
        }

        [Fact]
        public async Task Should_Fail_When_No_Address() {
            //arrange
            var studentRepo = GetInMemoryStudentRepository();
            var studentObj = new StudentDetails()
            {
                Id = 1,
                StudentId = "A1234567",
                FirstName = "Test FName",
                LastName = "Test LName",
            };

            //assert
            await Assert.ThrowsAsync<Exception>(() => studentRepo.AddAsync(studentObj));
        }
    }
}
