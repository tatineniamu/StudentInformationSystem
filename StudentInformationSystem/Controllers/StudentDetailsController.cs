using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentInformationSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInformationSystem.Controllers
{
    public class StudentDetailsController : Controller
    {
        private readonly IStudentDetailsRepository _studentDetailsRepository;
        public StudentDetailsController(IStudentDetailsRepository studentDetailsRepository) {
            _studentDetailsRepository = studentDetailsRepository;
        }

        // GET: StudentDetailsController
        public async Task<ActionResult> Index()
        {
            var studentList = await _studentDetailsRepository.GetAllAsync();
            return View();
        }

        // GET: StudentDetailsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudentDetailsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentDetailsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentDetailsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentDetailsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentDetailsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentDetailsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
