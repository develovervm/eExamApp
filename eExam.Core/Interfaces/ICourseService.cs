
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eExam.Core.Interfaces
{
    public interface ICourseService
    {
        List<Course> GetAllCourses();
        Course AddCourse(Course course);
        Course GetCourseById(int courseId);
        Course UpdateCourse(Course course);
        void DeleteCourse(int courseId);
    }
}
