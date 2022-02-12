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
        bool CheckStudentExists(int id);
        Task<StudentDetails> GetById(int id);
        Task AddAsync(StudentDetails studentDetails);
        Task UpdateAsync(StudentDetails studentDetails);
        Task DeleteAsync(StudentDetails studentDetails);
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

        public bool CheckStudentExists(int id)
        {
            return _dbContext.StudentDetails.Any(e => e.Id == id);
        }

        public async Task<StudentDetails> GetById(int id)
        {
            return await _dbContext.StudentDetails.Include(i => i.Address).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task AddAsync(StudentDetails studentDetails)
        {
            if (studentDetails.Address == null)
                throw new Exception("No Address Provided");

            _dbContext.StudentDetails.Add(studentDetails);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(StudentDetails studentDetails)
        {
            _dbContext.Attach(studentDetails).State = EntityState.Modified;
            _dbContext.Attach(studentDetails.Address).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(StudentDetails studentDetails)
        {
            _dbContext.Address.Remove(studentDetails.Address);
            _dbContext.StudentDetails.Remove(studentDetails);
            await _dbContext.SaveChangesAsync();
        }
    }
}
