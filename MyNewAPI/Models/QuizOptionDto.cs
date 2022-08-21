namespace Quiz.API.Models
{
    public class QuizOptionDto
    {
        public int Id { get; set; }
        public int QuizQuestionId { get; set; }
        public string Option { get; set; }        
        public int CorrectOption { get; set; }
    }
}
