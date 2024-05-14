using System.Net.NetworkInformation;
using UnitTestPlayground.DNS;

namespace UnitTestPlayground.Ping;
public class NetworkService
{
    private readonly IDNS _dns;

    public NetworkService(IDNS dNS)
    {
        _dns = dNS;
    }
    public string SendPing()
    {
        if (_dns.SendDNS())
        {
            return "Success: xxx";
        }
        return "Failed";
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
