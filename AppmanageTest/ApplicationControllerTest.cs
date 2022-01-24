using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using API.Controllers;
using App.Applications;
using App.Core;
using App.Interface;
using App.Repository;
using Application.Core;
using AutoMapper;
using Domain.Interfaces;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.CompilerServices;
using Moq;
using Shouldly;
using Xunit;
using Aplicacao = Domain.Application;

namespace AppmanageTest
{
    public class ApplicationControllerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAppmanagerRepository> _mockRepo;

        public ApplicationControllerTest()
        {
            _mockRepo = MockAppmanagerRepository.GetAppManagerRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfiles>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        //Details

        [Fact]
        public async Task Task_GetApplication_Return_OkResult()
        {
            var appId = Guid.Parse("0e2a8cb4-6bf2-4c0e-1b35-08d9dcd754f0");
            var handler = new Details.Handler(_mockRepo.Object);

            var result = await handler.Handle(new Details.Query { Id = appId }, CancellationToken.None);

            result.ShouldBeOfType<List<Aplicacao>>();

            //result.Count.ShouldBe(1);
        }

        //[Fact]
        //public void Task_GetApplication_Return_OkResult()
        //{
        //    //Arrange
        //    var appId = Guid.Parse("0e2a8cb4-6bf2-4c0e-1b35-08d9dcd754f0");
        //    _mediator.Setup(x => x.Send(Details.Query { Id = appId })).ReturnAsync(Aplicacao app);


        //    //Act
        //    var result =  controlle.GetApplication(appId);

        //    //Assert
        //    Assert.IsType<OkObjectResult>(result);
        //}
        //[Fact]
        //public async void Task_GetApplication_Return_NotResult()
        //{
        //    //Arrange
        //    var appId = Guid.Parse("0E2A8CB4-6BF2-4C0E-1B35-08D9DCD754F5");

        //    //Act
        //    var app = await _applicationsController.GetApplication(appId);

        //    //Assert
        //    Assert.IsType<NotFoundResult>(app);
        //}
        //[Fact]
        //public async void Task_GetApplication_Return_BadRequestResult()
        //{
        //    //Arrange  
        //    Guid? postId = null;

        //    //Act  
        //    var app = await _applicationsController.GetApplication(postId);

        //    //Assert  
        //    Assert.IsType<BadRequestResult>(app);
        //}
        //[Fact]
        //public async void Task_GetApplication_MatchResult()
        //{
        //    //Arrange
        //    var appId = Guid.Parse("0e2a8cb4-6bf2-4c0e-1b35-08d9dcd754f0");

        //    //Act
        //    var app = await _applicationsController.GetApplication(appId);

        //    //Assert
        //    Assert.IsType<OkObjectResult>(app);
        //    var okResult = app.Should().BeOfType<OkObjectResult>().Subject;
        //    var appTest = okResult.Value.Should().BeAssignableTo<Aplicacao>().Subject;

        //    Assert.Equal(@"C:\Program Files\WinRAR", appTest.PathLocal);
        //    Assert.Equal("https://www.WinRAR.com/", appTest.Url);
        //}

        //List

        //[Fact]
        //public async void Task_GetApplications_Return_OkResult()
        //{
        //    //Act
        //    var app = await _applicationsController.GetApplications();

        //    //Assert
        //    Assert.IsType<OkObjectResult>(app);
        //}
        //[Fact]
        //public async void Task_GetApplications_Return_BadRequestResult()
        //{
        //    //Act
        //    var app = await _applicationsController.GetApplications();
        //    app = null;

        //    //Assert
        //    if (app != null) Assert.IsType<NotFoundResult>(app);
        //}
        //[Fact]
        //public async void Task_GetApplications_MatchResult()
        //{
        //    //Act
        //    var app = await _applicationsController.GetApplications();

        //    //Assert
        //    Assert.IsType<OkObjectResult>(app);
        //    var okResult = app.Should().BeOfType<OkObjectResult>().Subject;
        //    var appTest = okResult.Value.Should().BeAssignableTo<List<Aplicacao>>().Subject;

        //    foreach (var item in appTest)
        //    {
        //        if (item.Id != Guid.Parse("0E2A8CB4-6BF2-4C0E-1B35-08D9DCD754F0")) continue;
        //        Assert.Equal(@"C:\Program Files\WinRAR", item.PathLocal);
        //        Assert.Equal("https://www.WinRAR.com/", item.Url);
        //    }

        //}

        //// Create

        //[Fact]
        //public async void Task_Add_Application_Return_OkResult()
        //{
        //    //Arrange
        //    var app = new Aplicacao()
        //    {
        //        Id = Guid.Parse("0E2A8CB4-6BF2-4C0E-1B35-08D9DCD754F0"),
        //        Url = "www.OpenVPN.com",
        //        PathLocal = @"C:\Program Files\OpenVPN",
        //        DebuggingMode = false
        //    };

        //    //Act
        //    var result = await _applicationsController.CreateApplication(app);

        //    //Assert
        //    Assert.IsType<OkObjectResult>(result);
        //}
        //[Fact]
        //public async void Task_Add_Application_Return_BadRequest()
        //{
        //    //Arrange
        //    var app = new Aplicacao()
        //    {
        //        // aplicacao faltando campo Url
        //        Id = Guid.Parse("AC4D656B-72DF-42CD-1B36-08D9DCD754F0"),
        //        PathLocal = @"C:\Program Files\nodejs",
        //        DebuggingMode = false
        //    };

        //    //Act
        //    var result = await _applicationsController.CreateApplication(app);

        //    //Assert
        //    Assert.IsType<BadRequestResult>(result);
        //}
        //[Fact]
        //public async void Task_Add_Application_MatchResult()
        //{
        //    //Arrange
        //    var app = new Aplicacao()
        //    {
        //        Id = Guid.Parse("AC4D656B-72DF-42CD-1B36-08D9DCD754F1"),
        //        Url = "www.java.com",
        //        PathLocal = @"C:\Program Files\Java",
        //        DebuggingMode = false
        //    };

        //    //Act
        //    var result = await _applicationsController.CreateApplication(app);

        //    //Assert
        //    Assert.IsType<OkObjectResult>(app);
        //    var okResult = app.Should().BeOfType<OkObjectResult>().Subject;
        //    Assert.Equal(3, okResult.Value);

        //}

        ////Update

        //[Fact]
        //public async void Task_Update_Application_Return_OkResult()
        //{
        //    //Arrange
        //    var appId = Guid.Parse("0E2A8CB4-6BF2-4C0E-1B35-08D9DCD754F0");

        //    //Act  
        //    var existingApp = await _applicationsController.GetApplication(appId);
        //    var okResult = existingApp.Should().BeOfType<OkObjectResult>().Subject;
        //    var result = okResult.Value.Should().BeAssignableTo<Aplicacao>().Subject;

        //    var app = new Aplicacao()
        //    {
        //        Id = result.Id,
        //        Url = result.Url,
        //        PathLocal = result.PathLocal,
        //        DebuggingMode = result.DebuggingMode
        //    };

        //    var updatedApp = await _applicationsController.EditApplication(appId, app);

        //    //Assert  
        //    Assert.IsType<OkResult>(updatedApp);
        //}
        //[Fact]
        //public async void Task_Update_Application_Return_BadRequest()
        //{
        //    //Arrange
        //    var appId = Guid.Parse("0E2A8CB4-6BF2-4C0E-1B35-08D9DCD754F0");

        //    //Act  
        //    var existingApp = await _applicationsController.GetApplication(appId);
        //    var okResult = existingApp.Should().BeOfType<OkObjectResult>().Subject;
        //    var result = okResult.Value.Should().BeAssignableTo<Aplicacao>().Subject;

        //    var app = new Aplicacao()
        //    {
        //        // app sem Url
        //        Id = result.Id,
        //        PathLocal = result.PathLocal,
        //        DebuggingMode = result.DebuggingMode
        //    };

        //    var updatedApp = await _applicationsController.EditApplication(appId, app);

        //    //Assert  
        //    Assert.IsType<BadRequestResult>(updatedApp);
        //}
        //[Fact]
        //public async void Task_Update_Application_Return_NotFound()
        //{
        //    //Arrange
        //    var appId = Guid.Parse("0E2A8CB4-6BF2-4C0E-1B35-08D9DCD754F0");

        //    //Act  
        //    var existingApp = await _applicationsController.GetApplication(appId);
        //    var okResult = existingApp.Should().BeOfType<OkObjectResult>().Subject;
        //    var result = okResult.Value.Should().BeAssignableTo<Aplicacao>().Subject;

        //    var app = new Aplicacao()
        //    {
        //        Id = result.Id,
        //        Url = result.Url,
        //        PathLocal = result.PathLocal,
        //        DebuggingMode = result.DebuggingMode
        //    };

        //    var updatedApp = await _applicationsController.EditApplication(Guid.Parse("0E2A8CB4-6BF2-4C0E-1B35-08D9DCD754F9"), app);

        //    //Assert  
        //    Assert.IsType<NotFoundResult>(updatedApp);
        //}

        ////Delete
        //[Fact]
        //public async void Task_Delete_Application_Return_OkResult()
        //{
        //    //Arrange  
        //    var appId = Guid.Parse("0E2A8CB4-6BF2-4C0E-1B35-08D9DCD754F0");

        //    //Act  
        //    var result = await _applicationsController.DeleteApplication(appId);

        //    //Assert  
        //    Assert.IsType<OkResult>(result);
        //}
        //[Fact]
        //public async void Task_Delete_Application_Return_NotFoundResult()
        //{
        //    //Arrange  
        //    var appId = Guid.Parse("0E2A8CB4-6BF2-4C0E-1B35-08D9DCD754F9");

        //    //Act  
        //    var result = await _applicationsController.DeleteApplication(appId);

        //    //Assert  
        //    Assert.IsType<NotFoundResult>(result);
        //}
        //[Fact]
        //public async void Task_Application_Return_BadRequestResult()
        //{
        //    //Arrange  
        //    Guid? postId = null;

        //    //Act  
        //    var result = await _applicationsController.DeleteApplication(postId);

        //    //Assert  
        //    Assert.IsType<BadRequestResult>(result);
        //}
    }
}