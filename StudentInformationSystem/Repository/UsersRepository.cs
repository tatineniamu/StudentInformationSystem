using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.DataBase;
using StudentInformationSystem.DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInformationSystem.Repository
{
    public interface IUsersRepository
    {
        Task<Users> UserLogin(Users userDetails);
    }
    
    public class UsersRepository : IUsersRepository
    {
        protected readonly DataContext _dbContext;
        public UsersRepository(DataContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<Users> UserLogin(Users userDetails) {
            var user = await _dbContext.Users.FirstOrDefaultAsync(f => f.UserName == userDetails.UserName && f.Password == userDetails.Password);
            return user;
        }
    }
}
