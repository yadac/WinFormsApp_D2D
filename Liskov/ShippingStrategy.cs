using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liskov
{
    public class ShippingStrategy : IShipping
    {
        private decimal _flatRate;
        public decimal FlatRate
        {
            get
            {
                return _flatRate;
            }
            set
            {
                // ガード句で条件精査
                if (value <= decimal.Zero)
                    throw new ArgumentException("flatRate", $"Flat rate must be positive and non-zero");
                _flatRate = value;
            }
        }

        public ShippingStrategy(decimal flatRate)
        {
            FlatRate = flatRate;
        }

        public virtual decimal CalculateShippingCost(
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

            // 送料計算
            var shippingCost = decimal.One;

            // 事後条件 = ガード句 = contract(契約)の適用
            if (shippingCost <= decimal.Zero)
                throw new ArgumentException("return", $"The return value is out of range.");

            return shippingCost;
        }

    }
}
