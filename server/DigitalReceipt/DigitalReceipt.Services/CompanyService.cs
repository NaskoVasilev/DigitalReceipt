using CaseManager.Services;
using DigitalReceipt.Data;
using DigitalReceipt.Data.Models;

namespace DigitalReceipt.Services
{
    public class CompanyService : BaseService<Company, int>, ICompanyService
    {
        private readonly ApplicationDbContext context;

        public CompanyService(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
