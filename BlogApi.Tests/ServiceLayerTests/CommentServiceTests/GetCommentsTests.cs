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
    public class GetCommentsTests
    {
        private MockRepository _mockRepository;
        private Mock<IPostRepository> _postRepository;
        private Mock<ICommentRepository> _commentRepository; 

        private ICommentService _commentService;

        [SetUp]
        public void SetUp() 
        {
            _mockRepository = new MockRepository(MockBehavior.Strict) {DefaultValue = DefaultValue.Mock};
            _postRepository = _mockRepository.Create<IPostRepository>();
            _commentRepository = _mockRepository.Create<ICommentRepository>();

            _commentService = new CommentService(_postRepository.Object, _commentRepository.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _mockRepository.VerifyAll();
        }

        [Test]
        public void GetCommentsForPost_WithPostIdDoesntExist_ThrowsPostNotFoundException()
        {
            _postRepository.Setup(p => p.GetById("test")).Returns((Post)null);

            Assert.Throws<PostNotFoundException>(() => _commentService.GetPostComments("test", 1));
        }
    }
}