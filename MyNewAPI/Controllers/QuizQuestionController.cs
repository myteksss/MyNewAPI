using Microsoft.AspNetCore.Mvc;
using MyNewAPI;
using Quiz.API.Models;

namespace Quiz.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuizQuestionController : ControllerBase
    {
        [HttpGet]
        [Route("GetAllQuestion/{quizId}")]
        public ActionResult<IEnumerable<QuizQuestionsDto>> GetAllQuestion( int quizId)
        {
            var result = QuizNameDataStore.Current.QuizNames.FirstOrDefault(x => x.Id == quizId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result.QuizQuestion);
        }

        [HttpGet("GetQuestion/{quizId}/{questionId}")]
        public ActionResult<QuizQuestionsDto> GetQuestion(int quizId, int questionId)
        {
            var quiz = QuizNameDataStore.Current.QuizNames.FirstOrDefault(x => x.Id == quizId);            
            
            if (quiz == null)
            {
                return NotFound();
            }

            var question = quiz.QuizQuestion.FirstOrDefault(x => x.Id == questionId);

            if (question == null)
            {
                return NotFound();
            }
            
            return Ok(question);

        }

        [HttpPost("AddQuizQuestion")]
        public ActionResult<QuizQuestionsDto> AddQuizQuestion(int quizId, [FromBody] AddQuizQuestionsDto question)
        {

            var quiz = QuizNameDataStore.Current.QuizNames.FirstOrDefault(x => x.Id == quizId);
            if (quiz == null)
            {
                return NotFound();
            }

            var maxQuestionId = QuizNameDataStore.Current.QuizNames.SelectMany(x => x.QuizQuestion).Max(y => y.Id);

            var newQuizQuestion = new QuizQuestionsDto()
            {
                Id = ++maxQuestionId,
                QuizNameId = quizId,
                Question = question.Question,
                Level = question.Level
            };

            quiz.QuizQuestion.Add(newQuizQuestion);

            return Ok();
        }
    }
}
