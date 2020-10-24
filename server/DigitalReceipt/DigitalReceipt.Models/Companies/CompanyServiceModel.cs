using DigitalReceipt.Common.Mappings;
using DigitalReceipt.Data.Models;

namespace DigitalReceipt.Models.Companies
{
    public class CompanyServiceModel : IMapTo<Company>
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string UserId { get; set; }
    }
}
