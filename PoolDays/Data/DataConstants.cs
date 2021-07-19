using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolDays.Data
{
    public class DataConstants
    {
        public const int PoolManufacturerMinLength = 2;
        public const int PoolManufacturerMaxLength = 20;

        public const int PoolModelMinLength = 2;
        public const int PoolModelMaxLength = 30;

        public const int PoolDescriptionMinLength = 10;
        public const int PoolDescriptionMaxLength = 3000;

        public const int PoolVolumeMinValue = 1;
        public const int PoolVolumeMaxValue = 199;

        public const double PoolHeightMinValue = 0.50;
        public const double PoolHeightMaxValue = 4;

        public const int PoolLengthMinValue = 1;
        public const int PoolLengthtMaxValue = 5;

        public const double PoolWidthtMinValue = 1;
        public const double PoolWidthMaxValue = 5;

        public const int ImageURLStringMinLength = 15;
    }
}
