
using DataAccess.Entities;
using eExam.Core.Interfaces;
using eExamApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace eExamApp.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        public IActionResult CourseList()
        {
            var courses=_courseService.GetAllCourses();
            List<CourseVM> coursesList = new List<CourseVM>();
            foreach(var course in courses)
            {
                var courseVM = new CourseVM()
                {
                    Id = course.Id,
                    CourseName = course.CourseName,
                    CourseCode = course.CourseCode,
                    CourseDescription = course.CourseDescription
                };
                coursesList.Add(courseVM);  
            }
            ViewBag.CourseList = coursesList;
            return View();
        }
        public IActionResult AddCourse()
        {
            if (TempData["CourseId"] != null)
            {
                int courseId = Convert.ToInt32(TempData["CourseId"]);
                var course = _courseService.GetCourseById(courseId);
                var courseVM = new CourseVM()
                {
                    Id = course.Id,
                    CourseName = course.CourseName,
                    CourseCode = course.CourseCode,
                    CourseDescription = course.CourseDescription
                };
                ViewBag.Action = "Update";
                return View(courseVM);
            }
            else
            {
                ViewBag.Action = "Save";
                return View();
            }
            
        }
        public IActionResult EditCourse(string courseId)
        {
            TempData["CourseId"]=courseId;
            return RedirectToAction("AddCourse");
        }
        [HttpPost]
        public IActionResult AddCourse(CourseVM courseVM)
        {
            var newCourse = new Course();

            newCourse.CourseName = courseVM.CourseName;
            newCourse.CourseCode = courseVM.CourseCode;
            newCourse.CourseDescription = courseVM.CourseDescription;
            if (courseVM.Id > 0)
            {
                newCourse.Id = courseVM.Id;
                _courseService.UpdateCourse(newCourse);
            }
            else
            {
                _courseService.AddCourse(newCourse);
            }
            
            return RedirectToAction("CourseList");
        }

        public IActionResult DeleteCourse(string courseId)
        {
            if(!string.IsNullOrEmpty(courseId))
            {
                _courseService.DeleteCourse(Convert.ToInt32(courseId));
            }
            return RedirectToAction("CourseList");
        }
    }
}
