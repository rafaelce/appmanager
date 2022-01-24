using App.Interface;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppmanageTest
{
    public static class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUow = new Mock<IUnitOfWork>();
            var mockAppmanagerRepo = MockAppmanagerRepository.GetAppManagerRepository();

            mockUow.Setup(r => r.AppmanagerRepository).Returns(mockAppmanagerRepo.Object);

            return mockUow;
        }
    }
}
