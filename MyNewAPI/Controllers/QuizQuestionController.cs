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

        [HttpGet("GetQuestion/{quizId}/{questionId}", Name = "GetQuestion")]
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

        [HttpPost("AddQuizQuestion/{quizId}")]
        public ActionResult<QuizQuestionsDto> AddQuizQuestion(int quizId, [FromBody] AddQuizQuestionsDto question)
        {

            var quiz = QuizNameDataStore.Current.QuizNames.FirstOrDefault(x => x.Id == quizId);
            if (quiz == null)
            {
                return NotFound();
            }

            var maxQuestionId = QuizNameDataStore.Current.QuizNames.FirstOrDefault(x => x.Id == quizId).QuizQuestion.Max(y => y.Id);

            var maxQuizOptionId = QuizNameDataStore.Current.QuizNames.SelectMany(x => x.QuizQuestion).SelectMany(y => y.quizOption).Max(z => z.Id);

            var newQuizQuestion = new QuizQuestionsDto()
            {
                Id = ++maxQuestionId,
                QuizNameId = quizId,
                Question = question.Question,
                Level = question.Level,
                quizOption = new List<QuizOptionDto>
                            {
                               new QuizOptionDto()
                               {
                                   Id = ++maxQuizOptionId,
                                   QuizQuestionId = quizId,
                                   Option = question.quizOption.Select(x => x.Option).ToString(),
                                   CorrectOption = 1
                                   
                               } 
                }
            };

            quiz.QuizQuestion.Add(newQuizQuestion);

            return CreatedAtRoute("GetQuestion",
                new
                {
                    quizId = quizId,
                    ff = newQuizQuestion.Id
                }, newQuizQuestion);
        }
    }
}
