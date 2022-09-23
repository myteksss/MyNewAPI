using Quiz.API.Models;

namespace Quiz.API.Models
{
    public class AddQuizQuestionsDto
    {              
        public string Question { get; set; }
        public int Level { get; set; }
        public List<AddQuizOptionDto> quizOption { get; set; }       
    }
}
