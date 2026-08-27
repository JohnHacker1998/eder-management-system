using System.Reflection;
using Eder.Domain.Common;
using MediatR;
using NetArchTest.Rules;
using Xunit;

namespace Eder.ArchitectureTests;

public class LayeringTests
{
    private static readonly Assembly Domain = typeof(BaseEntity).Assembly;
    private static readonly Assembly Application = typeof(Eder.Application.DependencyInjection).Assembly;
    private static readonly Assembly Infrastructure = typeof(Eder.Infrastructure.DependencyInjection).Assembly;

    [Fact]
    public void Domain_Should_Not_Depend_On_Application() =>
        Assert.True(
            Types.InAssembly(Domain).ShouldNot().HaveDependencyOn("Eder.Application").GetResult().IsSuccessful
        );

    [Fact]
    public void Domain_Should_Not_Depend_On_Infrastructure() =>
        Assert.True(
            Types.InAssembly(Domain).ShouldNot().HaveDependencyOn("Eder.Infrastructure").GetResult().IsSuccessful
        );

    [Fact]
    public void Domain_Should_Not_Depend_On_Api() =>
        Assert.True(
            Types.InAssembly(Domain).ShouldNot().HaveDependencyOn("Eder.Api").GetResult().IsSuccessful
        );

    [Fact]
    public void Application_Should_Not_Depend_On_Infrastructure() =>
        Assert.True(
            Types.InAssembly(Application)
                .ShouldNot()
                .HaveDependencyOn("Eder.Infrastructure")
                .GetResult()
                .IsSuccessful
        );

    [Fact]
    public void Application_Should_Not_Depend_On_Api() =>
        Assert.True(
            Types.InAssembly(Application).ShouldNot().HaveDependencyOn("Eder.Api").GetResult().IsSuccessful
        );

    [Fact]
    public void Infrastructure_Should_Not_Depend_On_Api() =>
        Assert.True(
            Types.InAssembly(Infrastructure).ShouldNot().HaveDependencyOn("Eder.Api").GetResult().IsSuccessful
        );

    [Fact]
    public void Handlers_Should_Reside_In_Application() =>
        Assert.True(
            Types.InAssembly(Application)
                .That()
                .ImplementInterface(typeof(IRequestHandler<,>))
                .Should()
                .ResideInNamespace("Eder.Application")
                .GetResult()
                .IsSuccessful
        );
}
