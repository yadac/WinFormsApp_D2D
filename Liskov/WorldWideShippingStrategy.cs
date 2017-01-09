using System;
using System.Globalization;

namespace Liskov
{
    public class WorldWideShippingStrategy : ShippingStrategy
    {
        public WorldWideShippingStrategy(decimal flatRate) : base(flatRate)
        {
        }

        public override decimal CalculateShippingCost(
            float packageWeightInKilograms,
            Size<float> packageDimensionInInches,
            RegionInfo destination)
        {
            // 事前条件 = ガード句 = contract(契約)の適用
            if (packageWeightInKilograms <= 0f)
                throw new ArgumentException(
                    "packageWeightInKilograms", $"Package weight must be positive and non-zero");
            if (packageDimensionInInches.X <= 0f || packageDimensionInInches.Y <= 0f)
                throw new ArgumentException(
                    "packageDimensionsInInches", $"Package dimensions must be positive and non-zero");
            if (destination == null)
                throw new ArgumentException("destination", $"Destination mst be provided");
            return decimal.Zero;
        }


    }
}