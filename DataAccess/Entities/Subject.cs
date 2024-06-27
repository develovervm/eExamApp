using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Subject
    {
        public int Id { get; set; }
        public string SubjectName {  get; set; }
        public string SubjectType {  get; set; }
        public int Semester {  get; set; }
        public int CourseId {  get; set; }
    }
}
