using System;
using System.Threading.Tasks;
using ApplyNow.Core.Models;

namespace ApplyNow.Core.Services
{
    public interface IUserService : IService<User>
    {
        Task<User> GetWithResumeByIdAsync(int userId);

        Task<Resume> CreateResumeAsync(int userId, Resume resume);

        Resume UpdateResumeAsync(int userId, Resume resume);

        User UpdateUser(int userId, User user);

        void RemoveWithResume(int userId);

        void RemoveResumeWithUserById(int userId);
    }
}
