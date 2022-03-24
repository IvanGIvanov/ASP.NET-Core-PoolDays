using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PoolDays.Controllers;
using PoolDays.Data;
using PoolDays.Services.Statistics;
using PoolDays.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PoolDays.Test.Controllers
{
    public class HomeControllerTest
    {

        [Fact]
        public void ErrorShouldReturnView()
        {
            // Arrange
            var homeController = new HomeController(Mock.Of<IStatisticsService>(), null, Mock.Of<IMapper>());

            // Act
            var result = homeController.Error();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }
    }
}
