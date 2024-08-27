using AutoMapper;
using DailyPlanner.Model;
using DailyPlanner.Services.Dtos;
using DailyPlanner.Services.Mappers.Contracts;

namespace DailyPlanner.Services.Mappers
{
    public class AuthMapper : AbstractMapper<SignUpModel, SignUpDto>, IAuthMapper
    {
        protected override AutoMapper.IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SignUpModel, SignUpDto > ().ReverseMap();
            });
            return config.CreateMapper();
        }
    }
}
