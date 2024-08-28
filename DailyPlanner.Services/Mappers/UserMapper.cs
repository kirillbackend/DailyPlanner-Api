using AutoMapper;
using DailyPlanner.Model;
using DailyPlanner.Services.Dtos;
using DailyPlanner.Services.Mappers.Contracts;

namespace DailyPlanner.Services.Mappers
{
    public class UserMapper : AbstractMapper<User, UserDto>, IUserMapper
    {
        protected override AutoMapper.IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>().ReverseMap();
            });
            return config.CreateMapper();
        }
    }
}
