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
        [Route("QuizQuestion")]
        public ActionResult<IEnumerable<QuizQuestionsDto>> GetAllQuestion( int quizId)
        {
            var result = QuizNameDataStore.Current.QuizNames.FirstOrDefault(x => x.Id == quizId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result.QuizQuestion);
        }
    }
}
