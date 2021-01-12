﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerShop.WebUI.ViewModels.Manufacturer
{
    public class IndexManufacturerViewModel
    {
        public IEnumerable<Models.Manufacturer> Manufacturers { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public FilterManufacturerViewModel FilterManufacturerViewModel { get; set; }
        public SortManufacturerViewModel SortManufacturerViewModel { get; set; }
    }
}
