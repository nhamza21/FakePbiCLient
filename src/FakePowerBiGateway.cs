using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFakePowerBiClient;

//to be replaced with you nuget package
public class FakePowerBiGateway
{
    public FakePowerBiGateway(string apiKey, string connectionString, string userName, string userSecret)
    {

    }

    public string GetDocumentAsString(string documentName)
    {
        var outPut = $"Dear {documentName}, Wolcome to Ghomrassen";
        //Console.WriteLine(outPut);
        return outPut;
    }
}
