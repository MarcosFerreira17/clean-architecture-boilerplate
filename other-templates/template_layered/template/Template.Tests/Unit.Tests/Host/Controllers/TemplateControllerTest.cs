using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Template.Application.RequestFeatures;
using Template.Domain.Dtos;
using Template.Domain.Interfaces;
using Template.Presentation.Controllers;

namespace Unit.Tests.Presentation.Controllers;

public class TemplateControllerTest
{
    private readonly Mock<ITemplateService> _service;
    private readonly TemplateController _controller;
    public TemplateControllerTest()
    {
        _service = new Mock<ITemplateService>();
        _controller = new TemplateController(_service.Object);
    }

    [Fact(Skip = "Deve ser refatorado")]
    public async Task GetAll_ShouldReturn200()
    {
        //Arrange
        _service.Setup(x => x.PagedGetAll(It.IsAny<TemplateParameters>())).Returns(Task.FromResult(PagedList<TemplateDto>.ToPagedList(TemplateControllerFixture.AllEntities(), 1, 5)));
        /// Act
        var result = (OkObjectResult)await _controller.GetAll(It.IsAny<TemplateParameters>());
        /// Assert
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task GetById_ShouldReturn200()
    {
        //Arrange
        _service.Setup(x => x.GetById(1)).Returns(Task.FromResult(TemplateControllerFixture.AllEntities().Find(x => x.Id == 1)));
        /// Act
        var result = (OkObjectResult)await _controller.GetById(1);
        /// Assert
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task Create_ShouldReturn200()
    {
        //Arrange
        _service.Setup(s => s.Create(It.IsAny<TemplateDto>())).Returns(Task.FromResult(TemplateControllerFixture.NewEntity()));
        /// Act
        var result = (OkResult)await _controller.Create(TemplateControllerFixture.NewEntity());
        /// Assert
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task Update_ShouldReturn200()
    {
        //Arrange
        _service.Setup(s => s.Update(1, It.Is<TemplateDto>(d => d.Id == 1))).Returns(Task.FromResult(TemplateControllerFixture.NewEntity()));
        /// Act
        var result = (NoContentResult)await _controller.UpdateAsync(1, TemplateControllerFixture.NewEntity());
        /// Assert
        result.StatusCode.Should().Be(204);
    }

    [Fact]
    public async void Delete_ShouldReturn200()
    {
        //Arrange
        _service.Setup(s => s.Create(It.IsAny<TemplateDto>())).Returns(Task.FromResult(TemplateControllerFixture.NewEntity()));
        _service.Setup(s => s.Delete(It.IsAny<long>())).Returns(Task.FromResult(TemplateControllerFixture.NewEntity()));
        /// Act
        var result = (NoContentResult)await _controller.RemoveAsync(1);
        /// Assert
        result.StatusCode.Should().Be(204);
    }
}
