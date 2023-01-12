using CloudFiles.Models;
using CloudFiles.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CloudFiles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UserFileController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly UserFileService _userFileService;

        public UserFileController(DataContext dataContext, UserFileService userFileService)
        {
            _dataContext = dataContext;
            _userFileService = userFileService; 
        }

        [HttpGet("/api/UserFiles")]
        public async Task<ActionResult<List<UserFile>>> GetFiles()
        {
           return Ok(await _dataContext.UserFiles.ToListAsync<UserFile>());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<List<UserFile>>> GetFile(int Id)
        {
            var file = await _dataContext.UserFiles.SingleOrDefaultAsync(f => f.Id == Id);

            return Ok(file);
        }

        [HttpPost("api/AddFile")]
        public async Task<ActionResult> AddFile([FromBody]UserFileDto userFile)
        {
            if (userFile == null)
            {
                return BadRequest("Missing File");
            }
            var mappedFile = _userFileService.MapUserFileDto(userFile);
            _dataContext.Add(mappedFile);
            await _dataContext.SaveChangesAsync();
            return Ok();
        }


        [HttpPut]
        public async Task<ActionResult<UserFile>> UpdateFile(UserFileDto request)
        {

            if (request == null)
            {
                return BadRequest();
            }

            var fileToUpdate = await _dataContext.UserFiles.FindAsync(request.Id);
            if (fileToUpdate == null)
            {
                return BadRequest();
            }

            //File is mapped to convert base64 to Byte[]
            var mappedFile = _userFileService.MapUserFileDto(request);

            fileToUpdate.Name = mappedFile.Name;
            fileToUpdate.Description = mappedFile.Description;

            //If changes have been made to the content of the file, a new record will be created
            if(BitConverter.ToString(fileToUpdate.Content) != request.Content)
            {
                mappedFile.PreviousVersionId = fileToUpdate.Id;
                var newVersion = _userFileService.CalculateNewVersion(mappedFile.Version);
                if(newVersion != mappedFile.Version) { 
                    mappedFile.Version = newVersion;
                    await _dataContext.AddAsync(mappedFile);
                    await _dataContext.SaveChangesAsync();

                    return Ok();
                } else
                {
                    return BadRequest("Unable to create new version.");
                }
                
            }

            //If no content in the file was changed, but other properties were updated, update the record
            _dataContext.Update(fileToUpdate);
            await _dataContext.SaveChangesAsync();
                      
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<UserFile>>> DeleteFile(int Id)
        {
            if (Id == 0)
                return BadRequest("You must pass the Id of the File you wish to delete");

            var userFileToDelete = await _dataContext.UserFiles.FindAsync(Id);

            if (userFileToDelete == null)
                return NotFound();

            _dataContext.Remove(userFileToDelete);
            await _dataContext.SaveChangesAsync();
            return Ok();
        }

    }
}
