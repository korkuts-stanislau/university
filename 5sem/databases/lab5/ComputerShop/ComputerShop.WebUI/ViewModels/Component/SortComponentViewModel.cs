using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerShop.WebUI.ViewModels.Component
{
    public enum SortState
    {
        ComponentTypeNameAsc,
        ComponenTypeNameDesc,
        ModelAsc,
        ModelDesc,
        ManufacturerNameAsc,
        ManufacturerNameDesc,
        CountryNameAsc,
        CountryNameDesc,
        ReleaseDateAsc,
        ReleaseDateDesc,
        CharacteristicsAsc,
        CharacteristicsDesc,
        WarrantyInMonthsAsc,
        WarrantyInMonthsDesc,
        DescriptionAsc,
        DescriptionDesc,
        PriceAsc,
        PriceDesc
    }
    public class SortComponentViewModel
    {
        public SortState ComponentTypeNameSort { get; set; }
        public SortState ModelSort { get; set; }
        public SortState ManufacturerNameSort { get; set; }
        public SortState CountryNameSort { get; set; }
        public SortState ReleaseDateSort { get; set; }
        public SortState CharacteristicsSort { get; set; }
        public SortState WarrantyInMonthsSort { get; set; }
        public SortState DescriptionSort { get; set; }
        public SortState PriceSort { get; set; }
        public SortState Current { get; set; }

        public SortComponentViewModel(SortState sortOrder)
        {
            ComponentTypeNameSort = sortOrder == SortState.ComponentTypeNameAsc ? SortState.ComponenTypeNameDesc : SortState.ComponentTypeNameAsc;
            ModelSort = sortOrder == SortState.ModelAsc ? SortState.ModelDesc : SortState.ModelAsc;
            ManufacturerNameSort = sortOrder == SortState.ManufacturerNameAsc ? SortState.ManufacturerNameDesc : SortState.ManufacturerNameAsc;
            CountryNameSort = sortOrder == SortState.CountryNameAsc ? SortState.CountryNameDesc : SortState.CountryNameAsc;
            ReleaseDateSort = sortOrder == SortState.ReleaseDateAsc ? SortState.ReleaseDateDesc : SortState.ReleaseDateAsc;
            CharacteristicsSort = sortOrder == SortState.CharacteristicsAsc ? SortState.CharacteristicsDesc : SortState.CharacteristicsAsc;
            WarrantyInMonthsSort = sortOrder == SortState.WarrantyInMonthsAsc ? SortState.WarrantyInMonthsDesc : SortState.WarrantyInMonthsAsc;
            DescriptionSort = sortOrder == SortState.DescriptionAsc ? SortState.DescriptionDesc : SortState.DescriptionAsc;
            PriceSort = sortOrder == SortState.PriceAsc ? SortState.PriceDesc : SortState.PriceAsc;
            Current = sortOrder;
        }
    }
}
