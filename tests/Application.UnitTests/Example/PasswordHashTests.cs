using Application.Tools;
using FluentAssertions;
using NUnit.Framework;

namespace Application.UnitTests.Example;

public class PasswordHashTests
{
    [TestCase("test-password")]
    public void ShouldHashPassword(string password)
    {
        PasswordHasher.VerifyHashedPassword(PasswordHasher.HashPassword(password), 
            password).Should().BeTrue();
    }
}