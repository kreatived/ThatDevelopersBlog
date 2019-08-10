using BlogApi.DataAccessLayer.Repositories;
using BlogApi.DataLayer.Entities;
using BlogApi.Exceptions;
using BlogApi.ServiceLayer;
using BlogApi.ServiceLayer.Services;
using Moq;
using NUnit.Framework;

namespace BlogApi.Tests.ServiceLayerTests.PostsServiceTests
{
    [TestFixture]
    public class GetPostTests
    {
        private MockRepository _mockRepository;
        private Mock<IPostRepository> _postRepository;
        private Mock<ISlugService> _slugService; 

        private IPostService _postsService;

        [SetUp]
        public void SetUp() 
        {
            _mockRepository = new MockRepository(MockBehavior.Strict) {DefaultValue = DefaultValue.Mock};
            _postRepository = _mockRepository.Create<IPostRepository>();
            _slugService = _mockRepository.Create<ISlugService>();

            _postsService = new PostService(_slugService.Object, _postRepository.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _mockRepository.VerifyAll();
        }

        [Test]
        public void GetPost_WithSlugThatDoesntExist_ThrowsPostNotFoundException()
        {
            _postRepository.Setup(p => p.GetBySlug("test")).Returns((Post)null);

            Assert.Throws<PostNotFoundException>(() => _postsService.GetPost("test"));
        }
    }
}