using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.DataBase;
using StudentInformationSystem.DataBase.Entities;
using StudentInformationSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInformationSystem.Repository
{
    public interface IAssignmentRepository
    {
        List<Assignments> GetAssignmentsForStudent(int courseId);
        Task<HomeWork> CheckAndGetHomeWork(int assignmentId, int studentId);
        Task<bool> SaveHomeWork(HomeWork homeWork);
    }
    
    public class AssignmentRepository : IAssignmentRepository
    {
        protected readonly DataContext _dbContext;

        public AssignmentRepository(DataContext dbContext) 
        {
            _dbContext = dbContext;
        }


        public List<Assignments> GetAssignmentsForStudent(int courseId) {
            var assignmentslist = _dbContext.Assignments.Where(w => w.CourseId == courseId).ToList();
            return assignmentslist;
        }

        public async Task<HomeWork> CheckAndGetHomeWork(int assignmentId, int studentId) {
            var homeWorkObj = new HomeWork();
            var checkHomeWork = await _dbContext.HomeWork.FirstOrDefaultAsync(f => f.AssignmentId == assignmentId && f.StudentId == studentId);
            if (checkHomeWork != null)
            {
                homeWorkObj = checkHomeWork;
            }
            else {
                homeWorkObj.AssignmentId = assignmentId;
                homeWorkObj.StudentId = studentId;
            }
            return homeWorkObj;
        }

        public async Task<bool> SaveHomeWork(HomeWork homeWork) {
            try
            {
                homeWork.SubmittedDate = DateTime.Now;
                if (homeWork.Id > 0)
                {
                    _dbContext.HomeWork.Update(homeWork);
                }
                else
                {
                    await _dbContext.HomeWork.AddAsync(homeWork);
                }
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch{
                return false;
            }

        }

       
    }
}
