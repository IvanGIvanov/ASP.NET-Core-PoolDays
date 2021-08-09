using AutoMapper;
using PoolDays.Models.Pools;
using PoolDays.Services.Pools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolDays.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<PoolServiceModel, PoolFormModel>();
        }
    }
}
