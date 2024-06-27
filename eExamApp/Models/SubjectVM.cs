using Microsoft.AspNetCore.Mvc.Rendering;

namespace eExamApp.Models
{
    public class SubjectVM
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public string SubjectType { get; set; }
        public int Semester { get; set; }
        public int CourseId { get; set; }
        public List<SelectListItem> CourseList { get; set;}
        public List<SelectListItem> SemesterList { get; set; }
        public List<SelectListItem> SubjectTypeList {  get; set; }
    }
}
