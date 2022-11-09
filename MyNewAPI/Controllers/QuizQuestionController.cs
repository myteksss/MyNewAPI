using Microsoft.AspNetCore.JsonPatch;
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

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

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
                                   Option = question.quizOption[0].Option,
                                   CorrectOption = question.quizOption[0].CorrectOption
                               }
                }
            };

            quiz.QuizQuestion.Add(newQuizQuestion);

            return CreatedAtRoute("GetQuestion",
                new
                {
                    quizId = quizId,
                    questionId = newQuizQuestion.Id
                }, newQuizQuestion);
        }

        [HttpPut("UpdateQuizQuestion/{questionId}")]
        public ActionResult<QuizQuestionsDto> UpdateQuizQuestion(int quizId, int questionId, UpdateQuizQuestionDto updateQuizQuestionDto)
        {
            var quiz = QuizNameDataStore.Current.QuizNames.FirstOrDefault(x => x.Id == quizId);

            if (quiz == null)
            {
                return BadRequest();
            }

            var question = quiz.QuizQuestion.FirstOrDefault(x => x.Id == questionId);

            if (question == null)
            {
                return BadRequest();
            }

            question.Question = updateQuizQuestionDto.Question;
            question.Level = updateQuizQuestionDto.Level;

            return CreatedAtRoute("GetQuestion",
                new
                {
                    quizId = quizId,
                    questionId = questionId
                }, updateQuizQuestionDto);
        }

        [HttpPatch("PartiallyUpdateQuestion/{questionId}")]
        public ActionResult PartiallyUpdateQuestion(int quizId, int questionId,
            JsonPatchDocument<UpdateQuizQuestionDto> patchDocument)
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

            var questionPatch = new UpdateQuizQuestionDto()
            {
                Question = question.Question,
                Level = question.Level
            };

            patchDocument.ApplyTo(questionPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(questionPatch))
            {
                return BadRequest(ModelState);
            }

            question.Question = questionPatch.Question;
            question.Level = questionPatch.Level;

            return NoContent();
        }

        [HttpPut("DeleteQuizQuestion/{questionId}")]
        public ActionResult<QuizQuestionsDto> DeleteQuizQuestion(int quizId, int questionId)
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

            quiz.QuizQuestion.Remove(question);
            return NoContent();

        }
    }
}
