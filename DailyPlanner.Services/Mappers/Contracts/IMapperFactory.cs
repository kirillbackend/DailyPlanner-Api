﻿
namespace DailyPlanner.Services.Mappers.Contracts
{
    public interface IMapperFactory
    {
        T GetMapper<T>() where T : IMapper;
    }
}
