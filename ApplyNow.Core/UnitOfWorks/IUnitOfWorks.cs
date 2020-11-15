using System;
using System.Threading.Tasks;
using ApplyNow.Core.Models;
using ApplyNow.Core.Repositories;

namespace ApplyNow.Core.UnitOfWorks
{
    public interface IUnitOfWorks
    {
        IUserRepository Users { get; }

        ICompanyRepository Companies { get; }

        IApplyRepository Applys { get; }

        IRepository<Resume> Resumes { get;}

        IRepository<Announcement> Announcements { get; }

        Task CommitAsync();

        void Commit();
    }
}
