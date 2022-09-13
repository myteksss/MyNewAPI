using Quiz.API.Models;
using System.ComponentModel.DataAnnotations;

namespace Quiz.API.Models
{
    public class AddQuizQuestionsDto
    {        
        public int QuizNameId { get; set; }

        [Required(ErrorMessage = "You should provide a question value.")]
        [MaxLength(50)]
        public string Question { get; set; }
        
        [Required(ErrorMessage = "You should provide a level value.")]
        public int Level { get; set; }

        [Required(ErrorMessage = "You should provide a quizOption value.")]        
        public List<AddQuizOptionDto> quizOption { get; set; }       
    }
}
