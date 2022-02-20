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
    public interface ICourseRepository {
        Task<IEnumerable<Course>> GetAvailableCoursesAsync();
        Task<IEnumerable<Course>> GetRegisteredCoursesAsync(int studentId);
        Task<bool> RegisterCourse(int courseId, int studentId);
    }
    
    public class CourseRepository : ICourseRepository
    {
        protected readonly DataContext _dbContext;

        public CourseRepository(DataContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Course>> GetAvailableCoursesAsync()
        {
            try
            {
                return await _dbContext.Course.Include(i => i.StudentCourse).ToListAsync();
            }
            catch (Exception ex) {
                throw;
            }
        }

        public async Task<IEnumerable<Course>> GetRegisteredCoursesAsync(int studentId)
        {
            try
            {
                var data =  await _dbContext.StudentDetails.Include(i => i.StudentCourse).ThenInclude(ti => ti.Course).Where(w => w.Id == Convert.ToInt32(studentId)).ToListAsync();
                var studentCourse = data.SelectMany(s => s.StudentCourse);
                var courseList = new List<Course>();
                foreach (var course in studentCourse) {
                    courseList.Add(course.Course);
                }
                return courseList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> RegisterCourse(int courseId, int studentId)
        {
            try
            {
               
                //check if the course is already registered
                var courseCheck = _dbContext.StudentCourse.FirstOrDefault(f => f.StudentId == Convert.ToInt32(studentId) && f.CourseId == courseId);
                if (courseCheck == null)
                {
                    var studentCourse = new StudentCourse()
                    {
                        StudentId = studentId,
                        CourseId = courseId
                    };
                    await _dbContext.StudentCourse.AddAsync(studentCourse);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                else {
                    throw new Exception("Course is already registered");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
