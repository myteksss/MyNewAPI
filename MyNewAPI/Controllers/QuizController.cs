using Microsoft.AspNetCore.Mvc;
using MyNewAPI.Models;

namespace MyNewAPI.Controllers 
{ 
    [ApiController]
    [Route("[controller]")]
    public class QuizController : ControllerBase
    {
        
        [HttpGet]
        [Route("QuizNameGetAll")]
        public ActionResult<IEnumerable<QuizNameDto>> QuizNameGetAll()
        {
            var result = QuizNameDataStore.Current.QuizNames.ToList();            

            return Ok(result);
                
        }

        [HttpGet]
        [Route("QuizNameGetById/{quizNameId}")]
        public ActionResult<QuizNameDto> QuizNameGetById(int quizNameId)
        {
            var result = QuizNameDataStore.Current.QuizNames.FirstOrDefault(x => x.Id == quizNameId);    

            if (result == null)
            {
                return NotFound();
            }


            return Ok(result);
        }
    }


}

