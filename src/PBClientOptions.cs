using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFakePowerBiClient
{
    public class PBClientOptions
    {
        [Required]
        public string ApiKey { get; set; } = "";
        [Required]
        public string UserSecret { get; set;} = "";
        [Required]
        public string UserName { get; set;} = "";
        [Required]
        public string ConnectionString { get; set; } = "";
    }
}