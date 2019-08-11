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
    public class UpdatePostTests
    {
        private MockRepository _mockRepository;
        private Mock<IPostRepository> _postRepository;
        private Mock<ISlugService> _slugService;

        private ApplicationUser _appUser;
        private PostForUpdate _postForUpdate;
        private string _postId = "This is a test post id";
        private Post _post;

        private IPostService _postService;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict) { DefaultValue = DefaultValue.Mock };
            _postRepository = _mockRepository.Create<IPostRepository>();
            _slugService = _mockRepository.Create<ISlugService>();

            _appUser = new ApplicationUser { Id = "this is my id", Name = "Derek", Email = "me@me.com", AvatarUrl = null, Permissions = new Dictionary<string, bool>() };
            _postForUpdate = new PostForUpdate();
            _post = new Post
            {
                Id = _postId
            };

            _postService = new PostService(_slugService.Object, _postRepository.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _mockRepository.VerifyAll();
        }

        [Test]
        public void UpdatePost_UserDoesntHavePermission_ThrowsUnauthorizedOperationException()
        {
            Assert.Throws<UnauthorizedOperationException>(() => _postService.UpdatePost(_postId, _postForUpdate, _appUser));
        }

        [Test]
        public void UpdatePost_PostWithIdNotFound_ThrowsPostNotFoundException()
        {
            var id = "invalid id";
            _appUser.Permissions.Add("CanUpdatePosts", true);
            _postRepository.Setup(r => r.GetById(id)).Returns((Post)null);
            Assert.Throws<PostNotFoundException>(() => _postService.UpdatePost(id, _postForUpdate, _appUser));
        }

        [Test]
        public void UpdatePost_ValidRequest_UpdatesExistingPost()
        {
            var title = "Sample Title";
            _postForUpdate.Id = _postId;
            _postForUpdate.Title = title;
            _appUser.Permissions.Add("CanUpdatePosts", true);

            _slugService.Setup(s => s.GenerateSlugForPostTitle(title)).Returns("Sample-Title-123");
            _postRepository.Setup(r => r.GetById(_postId)).Returns(_post);
            _postRepository.Setup(r => r.Update(_postId, It.Is<Post>(p => p.Id == _postId)));
            _postService.UpdatePost(_postId, _postForUpdate, _appUser);

            _postRepository.Verify(r => r.Update(_postId, It.Is<Post>(p => p.Id == _postId)), Times.Once);
        }
    }
}