using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFakePowerBiClient
{
    public interface IPowerBiClient
    {
        string Name { get; }
        string GetDocumentAsString(string documentId);
    }
}