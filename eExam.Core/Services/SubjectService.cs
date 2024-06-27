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
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepo;
        public SubjectService(ISubjectRepository repository)
        {
            _subjectRepo = repository;
        }
        public Subject AddSubject(Subject subject)
        {
            return _subjectRepo.Add(subject);
        }

        public List<Subject> GetSubjects()
        {
            return _subjectRepo.GetAll();
        }
    }
}
