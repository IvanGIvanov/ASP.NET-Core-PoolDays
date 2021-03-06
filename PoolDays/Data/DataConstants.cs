namespace PoolDays.Data
{
    public class DataConstants
    {
        public class User
        {
            public const int UserFirstNameMinLength = 2;
            public const int UserFirstNameMaxLength = 15;

            public const int UserLastNameMinLength = 2;
            public const int UserLastNameMaxLength = 15;
        }

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
        
        public class Jacuzzi
        {
            public const int JacuzziManufacturerMinLength = 2;
            public const int JacuzziManufacturerMaxLength = 20;

            public const int JacuzziModelMinLength = 2;
            public const int JacuzziModelMaxLength = 30;

            public const int JacuzziDescriptionMinLength = 10;
            public const int JacuzziDescriptionMaxLength = 3000;

            public const double JacuzziVolumeMinValue = 0.15;
            public const int JacuzziVolumeMaxValue = 5;

            public const int JacuzziHeightMinValue = 50;
            public const int JacuzziHeightMaxValue = 200;

            public const int JacuzziLengthMinValue = 80;
            public const int JacuzziLengthMaxValue = 300;

            public const int JacuzziWidthtMinValue = 80;
            public const int JacuzziWidthMaxValue = 300;

            public const double JacuzziPriceMinValue = 50;
            public const double JacuzziPriceMaxValue = 15999.99;

            public const int ImageURLStringMinLength = 15;
        }

        public class Comment
        {
            public const int CommentMinLength = 2;
            public const int CommentMaxLength = 3000;
        }

        public class Article
        {
            public const int ArticleMinLength = 2;
            public const int ArticleMaxLength = 5000;
        }
    }
}
