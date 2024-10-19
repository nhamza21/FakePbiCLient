using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFakePowerBiClient;
public interface IPowerBiClientProvider
{
    IPowerBiClient GetPowerBiClient(string name);
}