using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplyNow.API.Controllers;
using ApplyNow.API.DTOs;
using ApplyNow.API.Mapping;
using ApplyNow.API.Models.Request;
using ApplyNow.Core.Models;
using ApplyNow.Core.Repositories;
using ApplyNow.Core.Services;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace ApplyNow.Tests
{
    [TestFixture]
    public class UsersControllerTest
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public async Task When_User_Is_Given_It_Should_Be_Return_Ok()
        {
            User user = new User() { Id = 10000, Email = "testuser@xyz.com", UserName = "testuser123", Password = "123123" };

            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(p => p.GetByIdAsync(10000)).Returns(Task.FromResult(user));

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapProfile());
            });
            var mapper = mockMapper.CreateMapper();

            var usersController = new UsersController(userServiceMock.Object, mapper, Mock.Of<IDistributedCache>(), Mock.Of<ILogger<UsersController>>());

            var actionResult = await usersController.GetById(10000);
            actionResult.Should().BeOfType<OkObjectResult>();

        }

        [Test]
        public async Task When_User_Is_Given_Null_It_Should_Be_Return_NotFound()
        {
            User user = null;

            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(p => p.GetByIdAsync(10001)).Returns(Task.FromResult(user));

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapProfile());
            });
            var mapper = mockMapper.CreateMapper();

            var usersController = new UsersController(userServiceMock.Object, mapper, Mock.Of<IDistributedCache>(), Mock.Of<ILogger<UsersController>>());

            var actionResult = await usersController.GetById(10001);
            actionResult.Should().BeOfType<OkObjectResult>();

        }

        [Test]
        public async Task When_Resume_Is_Given_It_Should_Be_Return_Ok()
        {
            User user = new User() { Id = 10000, Email = "testuser@xyz.com", UserName = "testuser123", Password = "123123" };

            Resume resume = new Resume()
            {
                Id = 10000,
                CreatedDate = DateTime.Now,
                Title = "Ux Designer",
                Educations = new List<Education>(),
                Experiences = new List<Experience>(),
                IsActive = true,
                UserId = 1000
            };

            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(p => p.GetByIdAsync(10000)).Returns(Task.FromResult(user));

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapProfile());
            });
            var mapper = mockMapper.CreateMapper();

            var usersController = new UsersController(userServiceMock.Object, mapper, Mock.Of<IDistributedCache>(), Mock.Of<ILogger<UsersController>>());

            var resumeRequestModel = new ResumeCreateRequestDto()
            {
                Title = "Ux Designer",
                Educations = new List<ResumeCreateRequestDto.EducationRequestDto>(),
                Experiences = new List<ResumeCreateRequestDto.Experience>()
            };

            var actionResult = await usersController.SaveWithResumeById(10000, resumeRequestModel);
            actionResult.Should().BeOfType<CreatedResult>();

        }
    }
}