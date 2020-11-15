using System;
using System.Threading.Tasks;
using ApplyNow.Core.Models;

namespace ApplyNow.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetWithResumeByIdAsync(int userId);
    }
}
