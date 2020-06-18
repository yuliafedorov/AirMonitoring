using BBL.Services.Impl;
using Catalog.DAL.UnitOfWork;
using CCL.Security;
using CCL.Security.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Xunit;
using BBL.Services.Interfaces;

namespace BBL.Tests
{
    public class RegionServiceTests
    {
        [Fact]
        public void Ctor_InputNull_ThrowArgumentNullException()
        {
            // Arrange
            IUnitOfWork nullUnitOfWork = null;

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(
                () => new RegionService(nullUnitOfWork)
            );
        }


        [Fact]
        public void GetRegions_UserIsAdmin_ThrowMethodAccessException()
        {
            // Arrange
            User user = new Admin(1, "test", 1);
            SecurityContext.SetUser(user);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            IRegionService regionService = new RegionService(mockUnitOfWork.Object);
            
        // Act
        // Assert
        Assert.Throws<MethodAccessException>(() => regionService.GetRegions(1, 10));
        }
    }
}

