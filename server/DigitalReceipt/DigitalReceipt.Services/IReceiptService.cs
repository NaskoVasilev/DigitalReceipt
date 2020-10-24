using CaseManager.Services;
using DigitalReceipt.Data.Models;
using DigitalReceipt.Models.Receipts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalReceipt.Services
{
    public interface IReceiptService : IBaseService<Receipt, int>
    {
        Task<int> Create(ReceiptInputModel model);

        IList<ReceiptByCompanyViewModel> GetUserReceipts(string userId);
    }
}
