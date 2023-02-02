using NetArchTest.Rules;
using Template.Application.Interfaces;

namespace Architecture.Tests;

public class AchitectureTests
{
    private const string TemplateDomainNamespace = "Template.Domain";
    private const string TemplateApplicationNamespace = "Template.Application";
    private const string TemplateInfrastructureNamespace = "Template.Infrastructure";
    private const string TemplatePresentationNamespace = "Template.Presentation";

    [Fact]
    public void Domain_Should_Not_HaveDependencyOnOtherProject()
    {
        var otherProjects = new[]
        {
            TemplateApplicationNamespace,
            TemplateInfrastructureNamespace,
            TemplatePresentationNamespace
        };

        var testResult = Types
                        .InNamespace(TemplateDomainNamespace)
                        .ShouldNot()
                        .HaveDependencyOnAll(otherProjects)
                        .GetResult();

        Assert.True(testResult.IsSuccessful);
    }

    [Fact]
    public void Application_Should_Not_HaveDependencyOnOtherProjects()
    {
        var otherProjects = new[]
        {
            TemplateInfrastructureNamespace,
            TemplatePresentationNamespace
        };

        var testResult = Types
                        .InNamespace(TemplateApplicationNamespace)
                        .ShouldNot()
                        .HaveDependencyOnAll(otherProjects)
                        .GetResult();

        Assert.True(testResult.IsSuccessful);
    }

    [Fact]
    public void Infrastrucuture_Should_Not_HaveDependencyOnOtherProjects()
    {
        var otherProjects = new[]
        {
            TemplateApplicationNamespace,
        };

        var testResult = Types
                        .InNamespace(TemplateInfrastructureNamespace)
                        .ShouldNot()
                        .HaveDependencyOnAll(otherProjects)
                        .GetResult();

        Assert.True(testResult.IsSuccessful);
    }

    [Fact(Skip = "Em revisão")]
    public void Presentation_Should_Not_HaveDependencyOnOtherProjects()
    {
        var otherProjects = new[]
        {
            TemplateDomainNamespace,
        };

        var testResult = Types
                        .InNamespace(TemplatePresentationNamespace)
                        .ShouldNot()
                        .HaveDependencyOnAll(otherProjects)
                        .GetResult();

        Assert.True(testResult.IsSuccessful);
    }

    [Fact]
    public void Controllers_Should_Have_NameEndingWithController()
    {
        var result = Types.InCurrentDomain()
                        .That().ResideInNamespace(TemplatePresentationNamespace + ".Controllers")
                        .And().AreClasses()
                        .Should().HaveNameEndingWith("Controller")
                        .GetResult();
        Assert.True(result.IsSuccessful);
    }

    [Fact]
    public void Middlewares_Should_Have_NameEndingWithMiddleware()
    {
        var result = Types.InCurrentDomain()
                        .That().ResideInNamespace(TemplatePresentationNamespace + ".Middlewares")
                        .And().AreClasses()
                        .Should().HaveNameEndingWith("Middleware")
                        .GetResult();
        Assert.True(result.IsSuccessful);
    }

    [Fact]
    public void ServiceInterfaces_Should_Have_NameEndingWithService()
    {
        var result = Types.InCurrentDomain()
                        .That().ResideInNamespace(TemplateApplicationNamespace + ".Interfaces")
                        .And().AreClasses()
                        .Should().HaveNameEndingWith("Service")
                        .GetResult();
        Assert.True(result.IsSuccessful);
    }

    [Fact]
    public void ServiceClasses_Should_Have_NameEndingWithService()
    {
        var result = Types.InCurrentDomain()
                        .That().ResideInNamespace(TemplateApplicationNamespace + ".Services")
                        .And().AreClasses()
                        .Should().HaveNameEndingWith("Service")
                        .GetResult();
        Assert.True(result.IsSuccessful);
    }

    [Fact]
    public void RepositoryInterfaces_Should_Have_NameEndingWithRepository()
    {
        var result = Types.InCurrentDomain()
                        .That().ResideInNamespace(TemplateInfrastructureNamespace + ".Interfaces")
                        .And().AreClasses()
                        .Should().HaveNameEndingWith("Repository")
                        .GetResult();
        Assert.True(result.IsSuccessful);
    }

    [Fact]
    public void ServiceClasses_ShouldImplement_IBaseService_Interface()
    {
        var result = Types.InCurrentDomain()
                        .That().ResideInNamespace(TemplateApplicationNamespace + ".Interfaces")
                        .And().AreClasses()
                        .Should().ImplementInterface(typeof(IBaseService<,>))
                        .GetResult();
        Assert.True(result.IsSuccessful);
    }
}
