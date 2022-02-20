using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StudentInformationSystem.DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInformationSystem.DataBase
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(DbContextOptions<DataContext> options = null, IConfiguration configuration = null) : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            if (Configuration != null)
                options.UseSqlServer(Configuration.GetConnectionString("SISDatabase"));
        }

        public DbSet<StudentDetails> StudentDetails { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<StudentCourse> StudentCourse { get; set; }
        public DbSet<Users> Users{ get; set; }
    }
}
