namespace Quiz.API.Models
{
    public class AddQuizOptionDto
    {
        public int QuizQuestionId { get; set; }
        public string Option { get; set; }
        public int CorrectOption { get; set; }
    }
}
