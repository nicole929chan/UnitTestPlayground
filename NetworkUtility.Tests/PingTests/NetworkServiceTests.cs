using FluentAssertions;
using UnitTestPlayground.Ping;

namespace UnitTestPlayground.Tests.PingTests;
public class NetworkServiceTests
{
    [Fact]
    public void NetworkService_SendPing_ReturnsString()
    {
        // Arrange
        var networkService = new NetworkService();

        // Act
        var result = networkService.SendPing();

        // Assert
        Assert.Equal("Success: xxx", result);

    }

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(2, 3, 5)]
    public void NetworkService_PingTimeout_ReturnsInt(int a, int b, int expected)
    {
        // Arrange
        var networkService = new NetworkService();

        // Act
        var result = networkService.PingTimeout(a, b);

        // Assert
        //Assert.Equal(expected, result);
        result.Should().Be(expected);
    }
}
