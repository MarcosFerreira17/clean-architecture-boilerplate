using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Template.Application.Services;
using Template.Domain.Entities;
using Template.Infrastructure.Automapper;
using Template.Infrastructure.Interfaces;
using Template.Infrastructure.Repositories;
using Unit.Tests.Presentation.Controllers;
using Unit.Tests.Infrastructure.Factories;

namespace Unit.Tests.Application.Services;

public class TemplateServicesTests
{
    private readonly TemplateService _service;
    private readonly IMapper _mapper;
    private readonly Mock<ITemplateRepository> _repository;
    private readonly ILogger<TemplateService> _logger;
    public TemplateServicesTests()
    {
        var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(new TemplateProfile()));
        _mapper = mapperConfig.CreateMapper();
        _service = new TemplateService(_repository.Object, _mapper, _logger);
    }
    // [Fact]
    // public async Task GetAll_ShouldReturn200()
    // {
    //     //Arrange
    //     _repository.Setup(x => x.FindAll()).Returns(Task.FromResult((IEnumerable<TemplateEntity>)TemplateControllerFixture.AllEntities()));
    //     /// Act
    //     var result = (OkObjectResult)await _service.GetAll();
    //     /// Assert
    //     result.Should().Be(null);
    // }

    // [Fact]
    // public async Task GetById_ShouldReturn200()
    // {
    //     //Arrange
    //     _repository.Setup(x => x.FindByCondition(x => x.Id == 1)).Returns(Task.FromResult(TemplateMockData.GetAllTemplate().Find(x => x.Id == 1)));
    //     /// Act
    //     var result = await _service.GetById(1);
    //     /// Assert
    //     result.Should().Be(null);
    // }

    // [Fact]
    // public async Task Create_ShouldReturn200()
    // {
    //     //Arrange
    //     _repository.Setup(s => s.Create(It.IsAny<TemplateDto>())).Returns(Task.FromResult(TemplateMockData.NewTemplate()));
    //     /// Act
    //     var result = (OkResult)await _service.Create(TemplateMockData.NewTemplateDto());
    //     /// Assert
    //     result.StatusCode.Should().Be(200);
    // }

    // [Fact]
    // public async Task Update_ShouldReturn200()
    // {
    //     //Arrange
    //     _repository.Setup(s => s.Update(1, It.Is<TemplateDto>(d => d.Id == 1))).Returns(Task.FromResult(TemplateMockData.NewTemplate()));
    //     /// Act
    //     var result = (OkResult)await _service.UpdateAsync(1, TemplateMockData.NewTemplateDto());
    //     /// Assert
    //     result.StatusCode.Should().Be(200);
    // }

    // [Fact]
    // public async void Delete_ShouldReturn200()
    // {
    //     //Arrange
    //     _repository.Setup(s => s.Create(It.IsAny<TemplateDto>())).Returns(Task.FromResult(TemplateMockData.NewTemplate()));
    //     _repository.Setup(s => s.Delete(It.IsAny<long>())).Returns(Task.FromResult(TemplateMockData.NewTemplate()));
    //     /// Act
    //     var result = (NoContentResult)await _service.RemoveAsync(1);
    //     /// Assert
    //     result.StatusCode.Should().Be(204);
    // }
}
