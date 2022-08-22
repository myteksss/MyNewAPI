using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace Quiz.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentationFileController : ControllerBase
    {
        private readonly FileExtensionContentTypeProvider _extensionContentTypeProvider;

        public DocumentationFileController(FileExtensionContentTypeProvider extensionContentTypeProvider)
        {
            _extensionContentTypeProvider = extensionContentTypeProvider
                ?? throw new System.ArgumentNullException(
                    nameof(extensionContentTypeProvider));
        }

        [HttpGet]
        [Route("GetFile")]
        public ActionResult GetFile()
        {
            var pathToFile = "Documentation.pdf";

            if (!System.IO.File.Exists(pathToFile))
            {
                return NotFound();
            }

            if (_extensionContentTypeProvider.TryGetContentType(
                pathToFile, out var contentType))
            {
                contentType = "application/octet-stream";
            }           

            var file = System.IO.File.ReadAllBytes(pathToFile);
            return File(file, contentType, Path.GetFileName(pathToFile));
        }
    }
}
