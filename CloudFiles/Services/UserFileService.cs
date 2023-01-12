using CloudFiles.Models;
using System.Text;

namespace CloudFiles.Services
{
    public class UserFileService
    {
        public UserFileService() { }

        //This function is necessary to allow for restful transport of the userFile.Content as a base64 string, which must be a byte[] upon insertion.
        public UserFile MapUserFileDto(UserFileDto userFileDto)
        {
            var userFile = new UserFile();

            userFile.Description = userFileDto.Description;
            userFile.Name = userFileDto.Name;
            userFile.Id = userFileDto.Id;
            userFile.Version = userFileDto.Version;
            userFile.Content = Convert.FromBase64String(userFileDto.Content);

            return userFile;
        }

        public string CalculateNewVersion(string oldVersion)
        {
            bool versionConverted = Int64.TryParse(oldVersion, out var version);

            if (versionConverted)
            {
                version++;
                string newVersion = version.ToString();

                return newVersion;
            }

            return oldVersion;

        }
    }
}
