using Microsoft.AspNetCore.Mvc;
using MyNewAPI.Models;

namespace MyNewAPI.Controllers 
{ 
    [ApiController]
    [Route("[controller]")]
    public class QuizController : ControllerBase
    {

        private readonly QuizNameDataStore _quizNameDataStore;
        
        public QuizController(QuizNameDataStore quizNameDataStore)
        {
            _quizNameDataStore = quizNameDataStore;
        }

        [HttpGet]
        [Route("QuizNameGetAll")]
        public ActionResult<IEnumerable<QuizNameDto>> QuizNameGetAll()
        {
            var result = _quizNameDataStore.QuizNames.ToList();            

            return Ok(result);
                
        }

        [HttpGet]
        [Route("QuizNameGetById/{quizNameId}")]
        public ActionResult<QuizNameDto> QuizNameGetById(int quizNameId)
        {
            var result = _quizNameDataStore.QuizNames.FirstOrDefault(x => x.Id == quizNameId);    

            if (result == null)
            {
                return NotFound();
            }


            return Ok(result);
        }
    }


}

