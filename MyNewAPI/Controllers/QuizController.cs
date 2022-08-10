using Microsoft.AspNetCore.Mvc;


namespace MyNewAPI.Controllers 
{ 
    [ApiController]
    [Route("[controller]")]
    public class QuizController : ControllerBase
    {
        
        [HttpGet]
        [Route("QuizNameGetAll")]
        public JsonResult QuizNameGetAll()
        {
            return new JsonResult(QuizNameDataStore.Current.QuizNames);
                
        }

        [HttpGet]
        [Route("QuizNameGetById/{quizNameId}")]
        public JsonResult QuizNameGetById(int quizNameId)
        {
            var result = new JsonResult(QuizNameDataStore.Current.QuizNames.Where(x => x.Id == quizNameId));    

            return result;      
        }
    }


}

