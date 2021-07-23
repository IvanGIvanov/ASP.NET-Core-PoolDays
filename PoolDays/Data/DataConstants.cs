using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolDays.Data
{
    public class DataConstants
    {
        public class Pool
        {
            public const int PoolManufacturerMinLength = 2;
            public const int PoolManufacturerMaxLength = 20;

            public const int PoolModelMinLength = 2;
            public const int PoolModelMaxLength = 30;

            public const int PoolDescriptionMinLength = 10;
            public const int PoolDescriptionMaxLength = 3000;

            public const int PoolVolumeMinValue = 1;
            public const int PoolVolumeMaxValue = 199;

            public const int PoolHeightMinValue = 50;
            public const int PoolHeightMaxValue = 300;

            public const int PoolLengthMinValue = 80;
            public const int PoolLengthMaxValue = 5000;

            public const int PoolWidthtMinValue = 80;
            public const int PoolWidthMaxValue = 5000;

            public const int ImageURLStringMinLength = 15;
        }
        
        public class Employee
        {
            public const int EmployeeNameMinValue = 2;
            public const int EmployeeNameMaxValue = 20;

            public const int EmployeeNumberMinValue = 6;
            public const int EmployeeNumberMaxValue = 15;
        }        
    }
}
