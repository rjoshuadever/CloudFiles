using CloudFiles.Models;
using System.Text;

namespace CloudFiles.Services
{
    public class UserFileService
    {
        public UserFileService() { }

        public UserFile MapUserFileDto (UserFileDto userFileDto)
        {
            var userFile = new UserFile();

            userFile.Description = userFileDto.Description;
            userFile.Name= userFileDto.Name;
            userFile.Id = userFileDto.Id;
            userFile.Version = userFileDto.Version; 
            userFile.Content = Convert.FromBase64String(userFileDto.Content);
            
            return userFile;
        }
    }
}
