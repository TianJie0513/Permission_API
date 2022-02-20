using AutoMapper;
using DomainDTO.EFTables;
using DomainDTO.InputModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDTO.mapperConfig
{
   public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<SysOUsInputModels, SysOUsEFTables>();
            CreateMap<SysOUsEFTables, DomainDTO.RedisModels.SysOUsRedisModels>();
        }
    }
}
