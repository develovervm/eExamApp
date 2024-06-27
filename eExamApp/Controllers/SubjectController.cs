using DataAccess.Entities;
using eExam.Core.Interfaces;
using eExamApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eExamApp.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubjectService _subjectService;
        private readonly ICourseService _courseService;
        public SubjectController(ISubjectService subjectService, ICourseService courseService) 
        {
            _subjectService = subjectService;
            _courseService = courseService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult SubjectList()
        {
            var subjectList= _subjectService.GetSubjects();
            ViewBag.SubjectList=subjectList;
            return PartialView("_SubjectList");
        }
        public PartialViewResult AddSubject()
        {
            var courseList=_courseService.GetAllCourses();
            var dllCourse = new List<SelectListItem>();
            foreach (var course in courseList)
            {
                var courseItem = new SelectListItem()
                {
                    Value = course.Id.ToString(),
                    Text = course.CourseName
                };
                dllCourse.Add(courseItem);
            }
            SubjectVM subjectVM=new SubjectVM();

            //DropdownBinding
            subjectVM.CourseList=dllCourse;
            subjectVM.SemesterList=GetSemesterList();
            subjectVM.SubjectTypeList = GetSubjectTypeList();

            return PartialView("_AddSubject", subjectVM);
        }

        private List<SelectListItem> GetSubjectTypeList()
        {
            var list = new List<SelectListItem>();
            var type1 = new SelectListItem()
            {
                Value = "1",
                Text = "Theory"
            };
            var type2 = new SelectListItem()
            {
                Value = "2",
                Text = "Practical"
            };
            list.Add(type1);
            list.Add(type2);
            return list;
        }

        private List<SelectListItem> GetSemesterList()
        {
            var list= new List<SelectListItem>();
            var sem1 = new SelectListItem()
            {
                Value = "1",
                Text = "I"
            };
            var sem2 = new SelectListItem()
            {
                Value = "2",
                Text = "II"
            };
            var sem3 = new SelectListItem()
            {
                Value = "3",
                Text = "III"
            };
            var sem4 = new SelectListItem()
            {
                Value = "4",
                Text = "IV"
            };
            var sem5 = new SelectListItem()
            {
                Value = "5",
                Text = "V"
            };
            var sem6 = new SelectListItem()
            {
                Value = "6",
                Text = "VI"
            };

            list.Add(sem1);
            list.Add(sem2);
            list.Add(sem3);
            list.Add(sem4);
            list.Add(sem5);
            list.Add(sem6);
            return list;
        }
    }
}
