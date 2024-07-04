using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eExam.Core.Interfaces
{
    public interface ISubjectService
    {
        Subject AddSubject(Subject subject);
        List<Subject> GetSubjects();
        Subject GetSubject(int id);
    }
}
