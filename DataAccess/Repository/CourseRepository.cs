using DataAccess.Data;
using DataAccess.Entities;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _context;
        public CourseRepository(AppDbContext context)
        {
            _context = context;
        }
        public Course AddCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
            return course;
        }

        public void DeleteCourse(int id)
        {
            var dbCourse=_context.Courses.Where(x => x.Id == id).FirstOrDefault();
            if (dbCourse != null)
            {
                _context.Courses.Remove(dbCourse);
                _context.SaveChanges();
            }
        }

        public List<Course> GetAll()
        {
            return _context.Courses.ToList();   
        }

        public Course GetById(int id)
        {
            return _context.Courses.Where(x => x.Id == id).FirstOrDefault();
        }

        public Course UpdateCourse(Course course)
        {
            _context.Courses.Update(course);
            _context.SaveChanges();
            return course;
        }
    }
}
