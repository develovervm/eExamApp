using Microsoft.AspNetCore.Mvc.Rendering;

namespace eExamApp.Models
{
    public class QuestionAnswerVM
    {
        public int Id {  get; set; }
        public string Question { get; set; }
        public string AnswerOption1 { get; set; }
        public string AnswerOption2 { get; set; }
        public string AnswerOption3 { get; set; }
        public string AnswerOption4 { get; set; }
        public int MarksPerQuestion {  get; set; }
        public bool IsCorrectAnswer { get; set; }
        public int SubjectId {  get; set; }
        public List<SelectListItem> SubjectList { get; set; }
    }
}
