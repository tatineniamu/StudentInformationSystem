using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInformationSystem.Services
{
    public interface ISessionManager {
        void SetStudentSession(int id);
        string GetUserType();
        string GetStudentId();
    }
    
    public class SessionManager : ISessionManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISession _session;

        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor != null)
            {
                _httpContextAccessor = httpContextAccessor;
                _session = _httpContextAccessor.HttpContext.Session;
            }
        }

        public void SetStudentSession(int id)
        {
            _session.SetString("UserType", "Student");
            _session.SetString("StudentId", id.ToString());
        }

        public string GetUserType()
        {
            var message = _session.GetString("UserType");
            return message;
        }

        public string GetStudentId()
        {
            var message = _session.GetString("StudentId");
            return message;
        }
    }
}
