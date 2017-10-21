using Sitecore.Data;

namespace CarsRUs
{
    public struct Templates
    {
        public struct Customer
        {
            public static readonly ID ID = new ID("{F8CA835C-A7F5-4346-AC10-9983BE99632A}");
        }

        public struct CarPurchase
        {
            public static readonly ID ID = new ID("{17974EF8-F565-4716-A820-2E9DFC73A6A2}");

            public struct Fields
            {
                public static readonly ID Cars = new ID("{3BB8925F-6299-42B8-9CD6-C4FFD767B5FF}");
            }
        }

        public struct Car
        {
            public static readonly ID ID = new ID("{C3D6C1F7-E7D1-4E6B-A326-EC967D272354}");

            public struct Fields
            {
                public static readonly ID Make = new ID("{48DA02A5-E4C2-452A-A4ED-25E92D80BD34}");
            }
        }
    }
}