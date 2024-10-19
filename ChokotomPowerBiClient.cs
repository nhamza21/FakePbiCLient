using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFakePowerBiClient;
public class ChokotomPowerBiClient : IPowerBiClient
{
    public  string Name => "Chokotom";
    private readonly FakePowerBiGateway _client;
    public ChokotomPowerBiClient(FakePowerBiGateway client) 
    {
        _client = client;
    }

    public string GetDocumentAsString(string documentId)
    {
        return _client.GetDocumentAsString(documentId);
    }
}