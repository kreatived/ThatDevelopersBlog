using System.Collections.Generic;
using BlogApi.DataAccessLayer.Repositories;
using BlogApi.DataLayer.Entities;
using BlogApi.DTO.Posts;
using BlogApi.Exceptions;
using BlogApi.ServiceLayer;
using BlogApi.ServiceLayer.Models;
using BlogApi.ServiceLayer.Services;
using Moq;
using NUnit.Framework;

namespace BlogApi.Tests.ServiceLayerTests.PostsServiceTests
{
    [TestFixture]
    public class CreatePostTests
    {
        private MockRepository _mockRepository;
        private Mock<IPostRepository> _postRepository;
        private Mock<ISlugService> _slugService;

        private ApplicationUser _appUser;
        private PostForCreate _postForCreate;

        private IPostService _postService;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict) { DefaultValue = DefaultValue.Mock };
            _postRepository = _mockRepository.Create<IPostRepository>();
            _slugService = _mockRepository.Create<ISlugService>();

            _appUser = new ApplicationUser { Id = "this is my id", Name = "Derek", Email = "me@me.com", AvatarUrl = null, Permissions = new Dictionary<string, bool>() };
            _postForCreate = new PostForCreate();

            _postService = new PostService(_slugService.Object, _postRepository.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _mockRepository.VerifyAll();
        }

        [Test]
        public void CreatePost_UserDoesntHavePermission_ThrowsUnauthorizedOperationException()
        {
            Assert.Throws<UnauthorizedOperationException>(() => _postService.CreatePost(_postForCreate, _appUser));
        }

        [Test]
        public void CreatePost_ValidRequest_ReturnsNewPostObject()
        {
            var title = "Sample Title";
            _postForCreate.Title = title;
            _appUser.Permissions.Add("CanCreatePosts", true);

            _slugService.Setup(s => s.GenerateSlugForPostTitle(title)).Returns("Sample-Title-123");
            _postRepository.Setup(r => r.Insert(It.Is<Post>(p => p.Slug == "Sample-Title-123"))).Returns(new Post { Author = new Author()});
            var result = _postService.CreatePost(_postForCreate, _appUser);

            Assert.IsNotNull(result);
        }
    }
}