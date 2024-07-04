using DataAccess.Entities;
using eExam.Core.Interfaces;
using eExamApp.Helpers;
using eExamApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

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
            
            SubjectVM subjectVM=new SubjectVM();

            //DropdownBinding
            subjectVM.CourseList= GetCoueses(0);
            //subjectVM.SemesterList=GetSemesterList();
            ViewBag.Action = "Save";
            subjectVM.SemesterList = EnumHelper.GetSelectedListItems<Semesters>();
            subjectVM.SubjectTypeList = GetSubjectTypeList();

            return PartialView("_AddSubject", subjectVM);
        }
        [HttpPost]
        public ActionResult AddSubject(SubjectVM subjectVM)
        {

            return RedirectToAction("Index");
        }

        public PartialViewResult GetSubject(int subjectId)
        {
            var subject=_subjectService.GetSubject(subjectId);
            SubjectVM subjectVM = new SubjectVM();
            subjectVM.SubjectName = subject.SubjectName;
            //DropdownBinding

            subjectVM.CourseList = GetCoueses(subject.CourseId);
            //subjectVM.SemesterList=GetSemesterList();
            ViewBag.Action = "Update";
            subjectVM.SemesterList = EnumHelper.GetSelectedListItems<Semesters>();
            subjectVM.SubjectTypeList = GetSubjectTypeList();
            return PartialView("_AddSubject", subjectVM);
        }
        public ActionResult EditSubject(int subjectId)
        {
            return RedirectToAction("Index");
        }
        private List<SelectListItem> GetSubjectTypeList()
        {
            var list = new List<SelectListItem>();
            var type0 = new SelectListItem()
            {
                Value = "0",
                Text = "Select"
            };
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
            list.Add(type0); 
            list.Add(type1);
            list.Add(type2);
            return list;
        }
        private List<SelectListItem> GetCoueses(int selectedId)
        {
            var courseList = _courseService.GetAllCourses();
            var dllCourse = new List<SelectListItem>();
            dllCourse.Add(new SelectListItem() { Value = "0", Text = "Select" });
            foreach (var course in courseList)
            {
                var courseItem = new SelectListItem()
                {

                    Value = course.Id.ToString(),
                    Text = course.CourseName
                };
                if(selectedId > 0 && selectedId==course.Id)
                {
                    courseItem.Selected = true;
                }
                dllCourse.Add(courseItem);
            }
            return dllCourse;
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
