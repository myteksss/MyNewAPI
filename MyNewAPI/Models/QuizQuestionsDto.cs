using Quiz.API.Models;

namespace Quiz.API.Models
{
    public class QuizQuestionsDto
    {
        public int Id { get; set; }
        public int QuizNameId { get; set; }
        public string Question { get; set; }
        public int Level { get; set; }
        public List<QuizOptionDto> quizOption { get; set; }

       
    }
}
