using DataAccess.Entities;
using DataAccess.Interfaces;
using eExam.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eExam.Core.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepo;
        public CourseService(ICourseRepository repository)
        {
            _courseRepo = repository;
        }

        public Course AddCourse(Course course)
        {
            return _courseRepo.AddCourse(course);
        }
        public Course GetCourseById(int courseId)
        {
            return _courseRepo.GetById(courseId);
        }
        public List<Course> GetAllCourses()
        {
            return _courseRepo.GetAll();
        }

        public Course UpdateCourse(Course course)
        {
            return _courseRepo.UpdateCourse(course);
        }
        public void DeleteCourse(int courseId)
        {
            _courseRepo.DeleteCourse(courseId);
        }
    }
}
