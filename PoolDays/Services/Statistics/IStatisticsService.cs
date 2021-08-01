using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolDays.Services.Statistics
{
    public interface IStatisticsService
    {
        StatisticsServiceModel AllStatistics();
    }
}
