using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.DataBase;
using StudentInformationSystem.DataBase.Entities;
using StudentInformationSystem.Pages.Student;
using StudentInformationSystem.Repository;
using StudentInformationSystem.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace UnitTestSIS
{
    public class CourseUnitTest 
    {

        private ICourseRepository GetInMemoryStudentRepository()
        {
            DbContextOptions<DataContext> options;
            var builder = new DbContextOptionsBuilder<DataContext>();
            builder.UseInMemoryDatabase("SIS");
            options = builder.Options;
            DataContext sisDataContext = new DataContext(options);
            SetupData(sisDataContext);
            //sisDataContext.Database.EnsureDeleted();
            sisDataContext.Database.EnsureCreated();
            return new CourseRepository(sisDataContext, null);
        }

        internal void SetupData(DataContext dbContext) {
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
            
            var courseObj = new Course()
            {
                Id = 1,
                CourseId = "CS-001",
                CourseName = "AI"
            };

            dbContext.StudentDetails.Add(studentObj);
            dbContext.Course.Add(courseObj);
            dbContext.SaveChanges();
        }

        [Fact]
        public async Task Registering_Course_Should_Work() {
            //arrange
            var courseRepo = GetInMemoryStudentRepository();
           
            //act
            var result = await courseRepo.RegisterCourse(1, 1);

            //assert
            var registeredCourses = await courseRepo.GetRegisteredCoursesAsync(1);
            
            Assert.True(result);
            Assert.NotEmpty(registeredCourses);
            Assert.Single(registeredCourses.ToList());
        }

        [Fact]
        public async Task Get_Registered_Course_Should_Work()
        {
            //arrange
            var courseRepo = GetInMemoryStudentRepository();

            //act
            var result = await courseRepo.RegisterCourse(1, 1);
            var registeredCourses = await courseRepo.GetRegisteredCoursesAsync(1);

            //assert
            Assert.NotEmpty(registeredCourses);
        }

        [Fact]
        public async Task Get_All_Course_Should_Work()
        {
            //arrange
            var courseRepo = GetInMemoryStudentRepository();

            //act
            var result = await courseRepo.RegisterCourse(1, 1);
            var registeredCourses = await courseRepo.GetRegisteredCoursesAsync(1);

            //assert
            Assert.NotEmpty(registeredCourses);
        }

        [Fact]
        public async Task Should_Fail_Duplicate_Registration()
        {
            //arrange
            var courseRepo = GetInMemoryStudentRepository();
            var result = await courseRepo.RegisterCourse(1, 1);

            //assert
            await Assert.ThrowsAsync<Exception>(() => courseRepo.RegisterCourse(1, 1));
        }

    }
}
