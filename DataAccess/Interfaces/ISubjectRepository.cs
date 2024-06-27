using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface ISubjectRepository
    {
        Subject Add(Subject subject);
        Subject Update(Subject subject);
        Subject GetById(int id);
        List<Subject> GetAll();
        void Delete(int id);
    }
}
