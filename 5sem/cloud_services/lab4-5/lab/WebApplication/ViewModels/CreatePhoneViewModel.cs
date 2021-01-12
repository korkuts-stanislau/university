using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.ViewModels
{
    public class CreatePhoneViewModel
    {
        public SelectList Manufacturers { get; set; }
        public SelectList Countries { get; set; }
    }
}
