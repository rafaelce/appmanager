using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using App.Interface;
using Domain.Interfaces;
using Moq;
using Aplicacao = Domain.Application;

namespace AppmanageTest
{
    public static class MockAppmanagerRepository
    {
        
        public static Mock<IAppmanagerRepository> GetAppManagerRepository()
        {
            var applications = new List<Aplicacao>() {
                new Aplicacao() {
                    Id = Guid.Parse("0E2A8CB4-6BF2-4C0E-1B35-08D9DCD754F0"),
                    Url = "www.OpenVPN.com",
                    PathLocal = @"C:\Program Files\OpenVPN",
                    DebuggingMode = false
                    },
                new Aplicacao() {
                    Id = Guid.Parse("AC4D656B-72DF-42CD-1B36-08D9DCD754F0"),
                    Url = "www.nodejs.com",
                    PathLocal = @"C:\Program Files\nodejs",
                    DebuggingMode = false
                    },
                new Aplicacao() {
                    Id = Guid.Parse("AC4D656B-72DF-42CD-1B36-08D9DCD754F1"),
                    Url = "www.java.com",
                    PathLocal = @"C:\Program Files\Java",
                    DebuggingMode = false
                    },
            };

            var mockRepo = new Mock<IAppmanagerRepository>();
            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(applications);
            mockRepo.Setup(r => r.Add(It.IsAny<Aplicacao>())).ReturnsAsync((Aplicacao leaveType) =>
            {
                applications.Add(leaveType);
                return leaveType;
            });

            return mockRepo;
        }
     }
}