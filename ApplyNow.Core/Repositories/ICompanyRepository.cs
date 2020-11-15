using System;
using System.Threading.Tasks;
using ApplyNow.Core.Models;

namespace ApplyNow.Core.Repositories
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Task<Company> GetWithAnnouncementByIdAsync(int companyId);

    }
}
