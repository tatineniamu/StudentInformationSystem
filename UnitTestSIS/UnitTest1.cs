using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.DataBase;
using StudentInformationSystem.Pages.Student;
using StudentInformationSystem.Repository;
using System;
using System.Threading.Tasks;
using Xunit;

namespace UnitTestSIS
{
    public class UnitTest1
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
        public async Task Test1Async()
        {
            //arrange
            var studentRepo = GetInMemoryStudentRepository();

            //act
            var studentList = await studentRepo.GetAllAsync();

            //assert
            Assert.NotNull(studentList);
        }
    }
}
