using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.ViewModels
{
    public class CreateCinemaViewModel
    {
        public SelectList Cities { get; set; }
        public SelectList Types { get; set; }
    }
}
