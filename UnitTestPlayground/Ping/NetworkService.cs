using System.Net.NetworkInformation;

namespace UnitTestPlayground.Ping;
public class NetworkService
{
    public string SendPing()
    {
        return "Success: xxx";
    }

    public int PingTimeout(int a, int b)
    {
        return a + b;
    }

    public PingOptions GetPingOptions()
    {
        return new PingOptions()
        {
            DontFragment = true,
            Ttl = 64
        };
    }

    public IEnumerable<PingOptions> MostRecentPings()
    {
        IEnumerable<PingOptions> pingOptions = new[]
        {
            new PingOptions()
            {
                DontFragment = true,
                Ttl = 64
            },
            new PingOptions()
            {
                DontFragment = false,
                Ttl = 128
            }
        };

        return pingOptions;
    }
}
