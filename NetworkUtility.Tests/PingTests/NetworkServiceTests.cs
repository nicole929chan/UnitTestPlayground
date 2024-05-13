using FluentAssertions;
using UnitTestPlayground.Ping;

namespace UnitTestPlayground.Tests.PingTests;
public class NetworkServiceTests
{
    private readonly NetworkService _pingService;

    public NetworkServiceTests()
    {
        //SUT: System Under Test
        _pingService = new NetworkService();
    }
    [Fact]
    public void NetworkService_SendPing_ReturnsString()
    {
        // Arrange

        // Act
        var result = _pingService.SendPing();

        // Assert
        Assert.Equal("Success: xxx", result);

    }

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(2, 3, 5)]
    public void NetworkService_PingTimeout_ReturnsInt(int a, int b, int expected)
    {
        // Arrange

        // Act
        var result = _pingService.PingTimeout(a, b);

        // Assert
        //Assert.Equal(expected, result);
        result.Should().Be(expected);
    }
}
