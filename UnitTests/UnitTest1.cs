using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using AngularTest.Domain.Data;
using AngularTest.Domain.Interfaces;
using AngularTest.Domain.Models;
using AngularTest.Services.Services;
using Moq;
using Xunit;

namespace UnitTests
{
    public class UnitTest1
    {
        private List<Post> GetFakePosts()
        {
            var posts = new List<Post>()
            {
                new Post
                {
                    PostId = 1,
                    Title = "Test title",
                    Text = "Test text"
                },
                new Post
                {
                    PostId = 2,
                    Title = "Test title",
                    Text = "Test text"
                },
                new Post
                {
                    PostId = 3,
                    Title = "Test title",
                    Text = "Test text"
                },

            };
            return posts;
        }


        [Fact]
        public void GetExisingPost()
        {
            var inputId = 1;
            var PostsCollection = GetFakePosts();
            var existingPost = PostsCollection.First(x => x.PostId == inputId);

            var dbSrviceMock = new Mock<MyDbContext>();
            var repositoryMock = new Mock<IPost>();

            repositoryMock
                .Setup(dbPost => dbPost.GetById(inputId).Result)
                .Returns(existingPost);
            dbSrviceMock
                .Setup(service => service.Posts)
                .Returns(repositoryMock.Object);

            var postService = new PostService(dbSrviceMock.Object);
            var result = postService.GetById(inputId).Result;

            Assert.Equal(existingPost.PostId, result.PostId);
            Assert.Equal(existingPost.Text, result.Text);
            Assert.Equal(existingPost.Title, result.Title);
        }

        [Fact]
        public async Task GetNotExisingPost()
        {
            var inputId = 10;
            var dbSrviceMock = new Mock<MyDbContext>();
            var repositoryMock = new Mock<IPost>();

            repositoryMock
                .Setup(dbPost => dbPost.GetById(inputId).Result)
                .Returns(null as Post);
            dbSrviceMock
                .Setup(service => service.Posts)
                .Returns(repositoryMock.Object);

            var postService = new PostService(dbSrviceMock.Object);
            var ex = await Assert.ThrowsAsync<NullReferenceException>(() => postService.GetById(inputId));
            ex.Message.Contains("The selected post doesn't exist");
        }

        [Fact]
        public async Task GetPostsByUserId()
        {
            var userId = 1;

            var dbSrviceMock = new Mock<MyDbContext>();
            var repositoryMock = new Mock<IPost>();

            repositoryMock
                .Setup(dbPost => dbPost.GetAll().Result)
                .Returns(GetFakePosts());
            dbSrviceMock
                .Setup(service => service.Posts)
                .Returns(repositoryMock.Object);

            var postService = new PostService(dbSrviceMock.Object);
            var result = postService.GetAll().Result;
            result.Equals(GetFakePosts());
        }
    }
}
