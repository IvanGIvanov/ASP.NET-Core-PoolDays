using PoolDays.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolDays.Services.Statistics
{
    public class StatisticsService : IStatisticsService
    {
        private readonly PoolDaysDBContext data;

        public StatisticsService(PoolDaysDBContext data) => this.data = data;

        public StatisticsServiceModel AllStatistics()
        {
            return new StatisticsServiceModel
            {
                TotalPools = this.data.Pools.Count(),
                TotalUsers = this.data.Users.Count(),
            };
            
        }
    }
}
