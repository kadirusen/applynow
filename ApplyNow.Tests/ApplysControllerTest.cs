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
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace ApplyNow.Tests
{
    [TestFixture]
    public class ApplysControllerTest
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public async Task When_Apply_Is_Given_It_Should_Be_Return_Ok()
        {
            Apply apply = new Apply() { Id = 10000, AnnouncementId = 1, ResumeId = 1 };

            var applyServiceMock = new Mock<IApplyService>();
            applyServiceMock.Setup(p => p.GetByIdAsync(10000)).Returns(Task.FromResult(apply));

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapProfile());
            });
            var mapper = mockMapper.CreateMapper();

            var applysController = new ApplysController(applyServiceMock.Object, mapper, Mock.Of<ILogger<ApplysController>>());

            var actionResult = await applysController.GetById(10000);
            actionResult.Should().BeOfType<OkObjectResult>();

        }
    }
}
