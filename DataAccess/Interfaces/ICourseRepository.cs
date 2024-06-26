using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface ICourseRepository
    {
        Course AddCourse(Course course);
        Course UpdateCourse(Course course);
        void DeleteCourse(int id);
        List<Course> GetAll();
        Course GetById(int id);
    }
}
