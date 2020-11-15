using System;
using System.Threading.Tasks;
using ApplyNow.Core.Models;
using ApplyNow.Core.Repositories;
using ApplyNow.Core.UnitOfWorks;
using ApplyNow.Data.Repositories;

namespace ApplyNow.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWorks
    {
        private readonly AppDbContext _context;

        private UserRepository _userRepository;
        private CompanyRepository _companyRepository;
        private ApplyRepository _applyRepository;
        private Repository<Resume> _resumeRepository;
        private Repository<Announcement> _announcementRepository;


        public IUserRepository Users => _userRepository = _userRepository ?? new UserRepository(_context);
        public ICompanyRepository Companies => _companyRepository = _companyRepository ?? new CompanyRepository(_context);
        public IApplyRepository Applys => _applyRepository = _applyRepository ?? new ApplyRepository(_context);
        public IRepository<Resume> Resumes => _resumeRepository = _resumeRepository ?? new Repository<Resume>(_context);
        public IRepository<Announcement> Announcements => _announcementRepository = _announcementRepository ?? new Repository<Announcement>(_context);


        public UnitOfWork(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
