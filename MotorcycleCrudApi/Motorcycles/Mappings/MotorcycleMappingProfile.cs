using AutoMapper;
using MotorcycleCrudApi.Motorcycles.Dto;
using MotorcycleCrudApi.Motorcycles.Model;

namespace MotorcycleCrudApi.Motorcycles.Mappings
{
    public class MotorcycleMappingProfile : Profile
    {

        public MotorcycleMappingProfile()
        {
            CreateMap<CreateMotorcycleRequest, Motorcycle>();
        }

    }
}
