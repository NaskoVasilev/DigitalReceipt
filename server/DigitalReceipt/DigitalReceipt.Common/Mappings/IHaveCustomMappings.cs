using AutoMapper;

namespace DigitalReceipt.Common.Mappings
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IProfileExpression configuration);
    }
}
