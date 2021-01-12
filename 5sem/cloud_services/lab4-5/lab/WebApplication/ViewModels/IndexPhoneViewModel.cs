using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.ViewModels
{
    public class IndexPhoneViewModel
    {
        public List<CosmosTableSamples.Models.Phone> Phones { get; set; }
        public Dictionary<string, string> Countries { get; set; }
        public Dictionary<string, string> Manufacturers { get; set; }
    }
}
