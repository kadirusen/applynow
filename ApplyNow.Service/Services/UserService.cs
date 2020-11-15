using System;
using System.Linq;
using System.Threading.Tasks;
using ApplyNow.Core.Models;
using ApplyNow.Core.Repositories;
using ApplyNow.Core.Services;
using ApplyNow.Core.UnitOfWorks;
using Dawn;

namespace ApplyNow.Service.Services
{
    public class UserService : Service<User>, IUserService
    {

        public UserService(IUnitOfWorks unitOfWork, IRepository<User> repository ) : base(unitOfWork, repository)
        {
        }

        public async Task<User> GetWithResumeByIdAsync(int userId)
        {
            return await _unitOfWork.Users.GetWithResumeByIdAsync(userId);
        }

        public User UpdateUser(int userId, User user)
        {

            Guard.Argument(userId, nameof(userId)).NotDefault();

            user.Id = userId;
            _unitOfWork.Users.Update(user);
            _unitOfWork.Commit();

            return user;
        }

        public async Task<Resume> CreateResumeAsync(int userId, Resume resume)
        {
            Guard.Argument(userId, nameof(userId)).NotDefault();
            Guard.Argument(resume, nameof(resume)).NotNull();


            Guard.Argument(resume.Title, nameof(resume.Title)).NotNull().NotEmpty();

            if (!await _unitOfWork.Users.Exists(x=>x.Id==userId))
                return null; //TODO: service result {code:1001,message:"not found user",success:false}

            resume.UserId = userId;
            resume.CreatedDate = DateTime.Now;
            resume.IsActive = true;

            await _unitOfWork.Resumes.AddAsync(resume);
            await _unitOfWork.CommitAsync();

            return resume;
        }

        public Resume UpdateResumeAsync(int userId, Resume resume)
        {

            Guard.Argument(userId, nameof(userId)).NotDefault();
            Guard.Argument(resume, nameof(resume)).NotNull();

            Guard.Argument(resume.Title, nameof(resume.Title)).NotNull().NotEmpty();

            Resume dbResume = (_unitOfWork.Resumes.Where(x => x.UserId == userId).Result).FirstOrDefault();

            if (!_unitOfWork.Users.Exists(x => x.Id == userId).Result)
                return null; //TODO: service result {code:1001,message:"not found user",success:false}

            if (dbResume==null)
                return null; //TODO: service result {code:1001,message:"not found resume",success:false}


            dbResume.UserId = userId;
            dbResume.Title = resume.Title;
            dbResume.Educations = resume.Educations;
            dbResume.Experiences = resume.Experiences;


            dbResume.UpdateDate = DateTime.Now;


            _unitOfWork.Resumes.Update(dbResume);
            _unitOfWork.Commit();

            return resume;
        }

        public void RemoveWithResume(int userId)
        {
            Guard.Argument(userId, nameof(userId)).NotDefault();

            Resume resume = (_unitOfWork.Resumes.Where(x => x.UserId == userId).Result).FirstOrDefault();
            User user = (_unitOfWork.Users.Where(x => x.Id == userId).Result).FirstOrDefault();

            if (resume != null) {
                _unitOfWork.Resumes.Remove(resume);

            }

            _unitOfWork.Users.Remove(user);
            _unitOfWork.Commit();
        }

        public void RemoveResumeWithUserById(int userId)
        {
            Guard.Argument(userId, nameof(userId)).NotDefault();

            Resume resume = (_unitOfWork.Resumes.Where(x => x.UserId == userId).Result).FirstOrDefault();

            if (resume != null)
            {
                _unitOfWork.Resumes.Remove(resume);
                _unitOfWork.Commit();
            }

        }
    }
}
