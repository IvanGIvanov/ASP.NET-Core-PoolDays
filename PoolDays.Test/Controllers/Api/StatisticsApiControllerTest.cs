using PoolDays.Controllers.Api;
using PoolDays.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PoolDays.Test.Controllers.Api
{
    public class StatisticsApiControllerTest
    {
        [Fact]
        public void AllStatisticsShouldReturnTotalValues()
        {
            // Arrange
            var statisticsController = new StatisticsApiController(StatisticsServiceMock.Instance);

            // Act
            var result = statisticsController.GetStatistics();

            // Asserts
            Assert.NotNull(result);
            Assert.Equal(8, result.TotalPools);
            Assert.Equal(15, result.TotalUsers);
        }
    }
}
