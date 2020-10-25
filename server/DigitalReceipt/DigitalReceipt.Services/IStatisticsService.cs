using DigitalReceipt.Models.Common;
using System.Collections.Generic;

namespace DigitalReceipt.Services
{
    public interface IStatisticsService
    {
        IList<GroupingEntityViewModel<string, decimal>> GetSpendingByProductName(string userId);

        IList<GroupingEntityViewModel<string, decimal>> GetSpendingByProductCaegory(string userId);
    }
}
