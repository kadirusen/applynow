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
    public class CompaniesControllerTest
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public async Task When_Company_Is_Given_It_Should_Be_Return_Ok()
        {
            Company company = new Company() { Id = 10000, Name = "TEST Firma", Address = "Bursa/Türkiye" };

            var companyServiceMock = new Mock<ICompanyService>();
            companyServiceMock.Setup(p => p.GetByIdAsync(10000)).Returns(Task.FromResult(company));

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapProfile());
            });
            var mapper = mockMapper.CreateMapper();

            var companiesController = new CompaniesController(companyServiceMock.Object, mapper, Mock.Of<IDistributedCache>(), Mock.Of<ILogger<CompaniesController>>());

            var actionResult = await companiesController.GetById(10000);
            actionResult.Should().BeOfType<OkObjectResult>();

        }
    }
}
