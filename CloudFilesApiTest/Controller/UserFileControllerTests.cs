using AutoMapper;
using CloudFiles.Controllers;
using CloudFiles.Data;
using CloudFiles.Models;
using CloudFiles.Services;
using FakeItEasy;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;


namespace CloudFilesApiTest.Tests.Controller
{
    public class UserFileControllerTests
    {
        private readonly UserFileService _fileService;
        private readonly IMapper _mapper;

        public UserFileControllerTests()
        {
            _fileService = A.Fake<UserFileService>();
            _mapper = A.Fake<IMapper>();
        }

        [Fact]
        public void UserFileController_GetFiles_TaskRuns()
        {
            var _dataContext = new DataContext(new DbContextOptionsBuilder<DataContext>().Options);
            var files = A.Fake<ICollection<UserFile>>();
            var fileList = A.Fake<List<UserFile>>();

            A.CallTo(() => _mapper.Map<List<UserFile>>(files)).Returns(fileList);
            
            var controller = new UserFileController(_dataContext, _fileService);

            //Act
           var result = controller.GetFiles();
           

            //Assert
            result.Should().NotBeNull();
            //Need to make interfaces for Repo layer.
        }

    }
}
