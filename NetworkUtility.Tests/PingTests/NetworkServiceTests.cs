using FluentAssertions;
using System.Net.NetworkInformation;
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

    [Fact]
    public void NetworkService_GetPingOptions_ReturnsPingOptions()
    {
        // Arrange
        var expected = new PingOptions()
        {
            DontFragment = true,
            Ttl = 64
        };

        // Act
        var result = _pingService.GetPingOptions();

        // Assert
        result.Should().BeOfType<PingOptions>();
        result.DontFragment.Should().BeTrue();
        result.Ttl.Should().Be(64);
    }

    [Fact]
    public void NetworkService_MostRecentPings_ReturnsPingOptions()
    {
        // Arrange
        var expected = new PingOptions()
        {
            DontFragment = true,
            Ttl = 64
        };

        // Act
        var result = _pingService.MostRecentPings();

        // Assert
        result.Should().BeOfType<PingOptions[]>(); //型別檢查
        result.Should().ContainEquivalentOf(expected); //內容檢查
        result.Should().Contain(x => x.DontFragment == true); //內容檢查
    }
}
