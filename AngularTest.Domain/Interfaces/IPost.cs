using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AngularTest.Domain.Models;

namespace AngularTest.Domain.Interfaces
{
    public interface IPost
    {
        Task<Post> Create(Post post);
        Task<List<Post>> GetAll();
        Task<Post> GetById(int id);
        Task<Post> Edit(Post post);
        Task<Boolean> Delete(int id);
    }
}