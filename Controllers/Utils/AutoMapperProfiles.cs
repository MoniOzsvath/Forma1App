using AutoMapper;
using Forma1App.Controllers.Dtos;
using Forma1App.Models;

namespace Forma1App.Controllers.Utils
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Forma1TeamEntity, Forma1TeamReturnDto>();
            CreateMap<Forma1TeamUpdateDto, Forma1TeamEntity>();
            CreateMap<Forma1TeamAddDto, Forma1TeamEntity>();
        }
    }
}
