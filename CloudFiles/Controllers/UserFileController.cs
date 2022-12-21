using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CloudFiles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserFileController : ControllerBase
    {
        private List<UserFile> userFiles;

        public UserFileController() { }

        [HttpGet]
        public async Task<ActionResult<List<UserFile>>> GetFiles()
        {
            var files = new List<UserFile>();

            return Ok(files);
        }

        [HttpPost]
        public async Task<ActionResult<UserFile>> AddFile(UserFile userFile)
        {
            if (userFile == null)
            {
                return BadRequest();
            }

            userFiles.Add(userFile);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<UserFile>> UpdateFile(UserFile request)
        {

            if (request == null)
            {
                return BadRequest();
            }

            var fileToUpdate = userFiles.Find(f => f.Id == request.Id);
            if (fileToUpdate == null)
            {
                return BadRequest();
            }

          
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<UserFile>>> DeleteFile(int Id)
        {
            var userFileToDelete = userFiles.Find(f => f.Id == Id);
            if (userFileToDelete == null)
            {
                return BadRequest();
            }
            userFiles.Remove(userFileToDelete);
            return Ok(userFiles);
        }

    }
}
