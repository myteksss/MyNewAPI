using System.ComponentModel.DataAnnotations;

namespace Quiz.API.Models
{
    public class AddQuizOptionDto
    {
        public int QuizQuestionId { get; set; }

        [Required(ErrorMessage = "You should provide a option value.")]
        [MaxLength(50)]
        public string Option { get; set; }

        [Required(ErrorMessage = "You should provide a correct option value.")]
        public bool CorrectOption { get; set; }
    }
}
