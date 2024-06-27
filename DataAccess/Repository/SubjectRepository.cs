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
    public class SubjectRepository : ISubjectRepository
    {
        private readonly AppDbContext _context;
        public SubjectRepository(AppDbContext context)
        {
            _context = context;
        }
        public Subject Add(Subject subject)
        {
            _context.Subjects.Add(subject);
            _context.SaveChanges();
            return subject;
        }

        public void Delete(int id)
        {
            var dbSubject=_context.Subjects.FirstOrDefault(x => x.Id == id);
            if (dbSubject != null)
            {
                _context.Remove(dbSubject);
                _context.SaveChanges();
            }
        }

        public List<Subject> GetAll()
        {
            return _context.Subjects.ToList();
        }

        public Subject GetById(int id)
        {
            return _context.Subjects.FirstOrDefault(x => x.Id == id);
        }

        public Subject Update(Subject subject)
        {
            _context.Subjects.Update(subject);
            _context.SaveChanges();
            return subject;
        }
    }
}
