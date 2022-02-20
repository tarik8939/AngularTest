using System.Collections.Generic;
using System.Threading.Tasks;
using AngularTest.Domain.Data;
using AngularTest.Domain.Interfaces;
using AngularTest.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AngularTest.Domain.Repositories
{
    public class PostRepository : IPost
    {
        private readonly MyDbContext _context;

        public PostRepository()
        {
            _context = new MyDbContext(MyDbContext.ops.dbOptions);
        }


        public async Task<Post> Create(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<List<Post>> GetAll()
        {
            return await _context.Posts
                .ToListAsync();

        }

        public async Task<Post> GetById(int id)
        {
            return await _context.Posts
                .FirstOrDefaultAsync(x => x.PostId == id);
        }

        public async Task<Post> Edit(Post post)
        {
            _context.Entry(post).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<bool> Delete(int id)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(x=>x.PostId == id);
            if (post == null)
            {
                return false;
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}