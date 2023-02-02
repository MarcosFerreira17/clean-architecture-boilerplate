using System.Linq;
using FluentAssertions;
using Template.Domain.Entities;
using Template.Infrastructure.DataContext;
using Template.Infrastructure.Repositories;
using Unit.Tests.Infrastructure.Factories;

namespace Unit.Tests.Infrastructure.Repositories;

public class TemplateRepositoryTests
{
    private readonly TemplateDbContext _context;
    private readonly TemplateRepository _repository;
    public TemplateRepositoryTests()
    {
        _context = ContextFactory.Create();
        _repository = new TemplateRepository(_context);
    }
    [Fact]
    public async void GetAllSuccess()
    {
        //Arange
        _context.Template.AddRange(TemplateRepositoryFixture.AllEntities());
        _context.SaveChanges();
        //Act
        var result = await _repository.FindAll();
        //Assert
        result.Should().HaveCount(TemplateRepositoryFixture.AllEntities().Count);
    }

    [Fact]
    public void GetByConditionSuccess()
    {
        //Arange
        _context.Template.AddRange(TemplateRepositoryFixture.AllEntities());
        _context.SaveChanges();
        //Act
        var findByIdMock = TemplateRepositoryFixture.AllEntities().Find(x => x.ExampleString == "Need To Test this proj").ExampleString;
        var result = _repository.FindByCondition(x => x.ExampleString == "Need To Test this proj").FirstOrDefault().ExampleString;
        //Assert
        result.Should().Be(result, findByIdMock);
    }

    [Fact]
    public async void CreateSuccess()
    {
        //Arange
        await _repository.Create(TemplateRepositoryFixture.NewEntity());
        //Act
        var expectedCount = _repository.FindByCondition(x => x.Id >= 1);
        //Assert
        _context.Template.Count().Should().Be(expectedCount.Count());
    }

    [Fact]
    public async void UpdateSuccess()
    {
        TemplateEntity entity = new()
        {
            Id = 1,
            ExampleString = "teste"
        };

        await _repository.Create(entity);
        var oldEntity = _repository.FindByCondition(x => x.Id == 1).FirstOrDefault();

        entity.ExampleString = "teste update";

        var entityFromDb = _repository.Update(entity);
        var newEntity = _repository.FindByCondition(x => x.Id == 1).FirstOrDefault();
        Assert.NotEqual(oldEntity.ExampleString, newEntity.ExampleString);
    }

    [Fact]
    public async void DeleteSuccess()
    {
        TemplateEntity entity = new()
        {
            Id = 1,
            ExampleString = "teste"
        };
        await _repository.Create(entity);
        var createdEntity = _repository.FindByCondition(x => x.Id == 1).FirstOrDefault();

        var entityFromDb = _repository.Delete(entity);
        var deletedEntity = _repository.FindByCondition(x => x.Id == 1).FirstOrDefault();
        Assert.Null(deletedEntity);
    }
}
