using Quiz.API.Models;

namespace MyNewAPI.Models
{
    public class QuizNameDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
        public List<QuizQuestionsDto> QuizQuestion { get; set; }

        public int QuizQuestionCount { get { return QuizQuestion.Count; } }

    }
}