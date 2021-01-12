using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CosmosTableSamples.Models;

namespace WebApplication.ViewModels
{
    public class CinemaViewModel
    {
        public List<Cinema> Cinemas { get; set; }
        public Dictionary<string, string> Types { get; set; }
        public Dictionary<string, string> Cities { get; set; }
    }
}
