using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PoolDays.Controllers;
using PoolDays.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PoolDays.Test.Controllers
{
    public class ContactControllerTest
    {
        [Fact]
        public void ContactsShouldReturnView()
        {
            // Arrange
            var contacts = new ContactController();

            // Act
            var result = contacts.Contacts();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }
    }
}
