using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AngularTest.Domain.Interfaces;
using AngularTest.Domain.Models;
using AngularTest.Domain.Repositories;
using AngularTest.Services.DTO;

namespace AngularTest.Services.Services
{
    public class PostService
    {
        private readonly IPost _post;

        public PostService()
        {
            _post = new PostRepository();
        }

        public async Task<Post> Create(PostDto dto)
        {
            var post = new Post
            {
                Title = dto.Title,
                Text = dto.Text
            };
            var result = await this._post.Create(post);
            if (result.PostId > 0)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<ICollection<Post>> GetAll()
        {
            var posts = await this._post.GetAll();
            if (posts.Count > 0)
                return posts;
            else
                return null;
        }

        public async Task<Post> GetById(int id)
        {
            var post = await this._post.GetById(id);
            if (post == null)
                throw new NullReferenceException("The selected post doesn't exist"); ;
            return post;
        }

        public async Task<Post> Edit(int id, PostDto dto)
        {
            var post = await this._post.GetById(id);
            if (post != null)
            {
                post.Title = dto.Title;
                post.Text = dto.Text;
                var result = await this._post.Edit(post);
                return result;
            }
            return null;
        }

        public async Task<bool> Delete(int id)
        {
            var post = await this._post.GetById(id);
            if (post != null)
            {
                var resultPost = await this._post.Delete(id);
                return resultPost;
            }
            return false;
        }
    }
}