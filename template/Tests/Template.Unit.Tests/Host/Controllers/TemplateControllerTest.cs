using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Template.Application.Exceptions;
using Template.Application.RequestFeatures;
using Template.Domain.Dtos;
using Template.Application.Services.Interfaces;
using Template.Presentation.Controllers;
using Template.Tests.Helpers.MockData;

namespace Template.Tests.Host.Controllers;

public class TemplateControllerTest
{
    private readonly Mock<ITemplateService> _service;
    private readonly TemplateController _controller;
    public TemplateControllerTest()
    {
        _service = new Mock<ITemplateService>();
        _controller = new TemplateController(_service.Object);
    }

    [Fact]
    public async Task GetAll_ShouldReturn200()
    {
        var _service = new Mock<ITemplateService>();
        _service.Setup(x => x.GetAll()).Returns(Task.FromResult((IEnumerable<TemplateDto>)TemplateMockData.GetAllTemplateDto()));
        var _controller = new TemplateController(_service.Object);

        /// Act
        var result = (OkObjectResult)await _controller.GetAll(new TemplateParameters());
        /// Assert
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task GetById_ShouldReturn200()
    {
        //Arrange
        _service.Setup(x => x.GetById(1)).Returns(Task.FromResult(TemplateMockData.GetAllTemplateDto().Find(x => x.Id == 1)));
        /// Act
        var result = (OkObjectResult)await _controller.GetById(1);
        /// Assert
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task Create_ShouldReturn200()
    {
        //Arrange
        _service.Setup(s => s.Create(It.IsAny<TemplateDto>())).Returns(Task.FromResult(TemplateMockData.NewTemplate()));
        /// Act
        var result = (OkResult)await _controller.Create(TemplateMockData.NewTemplateDto());
        /// Assert
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task Update_ShouldReturn200()
    {
        //Arrange
        _service.Setup(s => s.Update(1, It.Is<TemplateDto>(d => d.Id == 1))).Returns(Task.FromResult(TemplateMockData.NewTemplate()));
        /// Act
        var result = (OkResult)await _controller.UpdateAsync(1, TemplateMockData.NewTemplateDto());
        /// Assert
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async void Delete_ShouldReturn200()
    {
        //Arrange
        _service.Setup(s => s.Create(It.IsAny<TemplateDto>())).Returns(Task.FromResult(TemplateMockData.NewTemplate()));
        _service.Setup(s => s.Delete(It.IsAny<long>())).Returns(Task.FromResult(TemplateMockData.NewTemplate()));
        /// Act
        var result = (NoContentResult)await _controller.RemoveAsync(1);
        /// Assert
        result.StatusCode.Should().Be(204);
    }
    [Fact]
    public async void Delete_ThrowsNotFoundException()
    {
        //Arrange
        _service.Setup(s => s.Delete(It.IsAny<long>())).Throws(new NotFoundException());
        /// Act
        var result = (ObjectResult)await _controller.RemoveAsync(1);
        /// Assert
        Assert.StrictEqual(StatusCodes.Status404NotFound, result.StatusCode);
    }
}
