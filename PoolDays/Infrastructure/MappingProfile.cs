using AutoMapper;
using PoolDays.Data.Models;
using PoolDays.Models.Home;
using PoolDays.Models.Jacuzzies;
using PoolDays.Models.Pools;
using PoolDays.Services.Jacuzzies;
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
            this.CreateMap<Pool, PoolIndexViewModel>();
            this.CreateMap<Pool, PoolServiceModel>();

            this.CreateMap<JacuzziServiceModel, JacuzziFormModel>();
            this.CreateMap<Jacuzzi, JacuzziServiceModel>();
        }
    }
}
