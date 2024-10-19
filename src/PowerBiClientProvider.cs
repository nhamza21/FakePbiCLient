using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFakePowerBiClient;
public class PowerBiClientProvider : IPowerBiClientProvider
{
    private readonly IDictionary<string, IPowerBiClient> _powerBiClientCache;

    public PowerBiClientProvider(IEnumerable<IPowerBiClient> clients)
    {
        _powerBiClientCache = clients.ToDictionary(x => x.Name);
    }
    public IPowerBiClient GetPowerBiClient(string name)
    {
        if (_powerBiClientCache.TryGetValue(name, out var result))
            return result;
        throw new ArgumentException($"No Client of name {name} is registred");
    }
}