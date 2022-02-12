using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.DataBase;
using StudentInformationSystem.DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInformationSystem.Repository
{
    public interface IStudentDetailsRepository {
        Task<IEnumerable<StudentDetails>> GetAllAsync();
    }
    
    public class StudentDetailsRepository: IStudentDetailsRepository
    {
        protected readonly DataContext _dbContext;
        public StudentDetailsRepository(DataContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<StudentDetails>> GetAllAsync()
        {
            return await _dbContext.StudentDetails.ToListAsync();
        }

        public Task AddAsync(StudentDetails studentDetails)
        {
            throw new NotImplementedException();
        }
    }
}
