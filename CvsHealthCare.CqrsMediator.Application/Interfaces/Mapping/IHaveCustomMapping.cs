using AutoMapper;

namespace CvsHealthCare.CqrsMediator.Application.Interfaces.Mapping
{
    public interface IHaveCustomMapping
    {
        void CreateMappings(Profile configuration);
    }
}
