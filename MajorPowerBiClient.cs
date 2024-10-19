using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFakePowerBiClient;
public class MajorPowerBiClient : IPowerBiClient
{
    public string Name => "Major";
    private readonly FakePowerBiGateway _client;

    public MajorPowerBiClient(FakePowerBiGateway client)
    {
        _client = client;
    }

    public string GetDocumentAsString(string documentId)
    {
        return _client.GetDocumentAsString(documentId);
    }
}