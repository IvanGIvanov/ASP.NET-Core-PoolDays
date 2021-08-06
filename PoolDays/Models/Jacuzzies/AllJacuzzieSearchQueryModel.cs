using PoolDays.Data.Models;
using PoolDays.Services.Jacuzzi;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoolDays.Models.Jacuzzies
{
    public class AllJacuzzieSearchQueryModel
    {
        public const int JacuzziPerPage = 3;

        public string Manufacturer { get; set; }

        public IEnumerable<string> Manufacturers { get; set; }

        [Display(Name = "Search Term:")]
        public string SearchTerm { get; set; }

        [Display(Name = "Sort by:")]
        public Sorting Sorting { get; init; }

        public int CurrentPage { get; set; } = 1;

        public int TotalJacuzzi { get; set; }

        public IEnumerable<JacuzziServiceModel> Jacuzzies { get; set; }
    }
}
