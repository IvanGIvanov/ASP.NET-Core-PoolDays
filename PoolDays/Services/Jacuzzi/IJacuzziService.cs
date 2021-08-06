using PoolDays.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolDays.Services.Jacuzzi
{
    public interface IJacuzziService
    {
        JacuzziQueryServiceModel All(
            string manufacturer,
            string searchTerm,
            Sorting sorting,
            int currentPage,
            int jacuzziPerPage);

        IEnumerable<string> AllJacuzziManufacturers();
    }
}

