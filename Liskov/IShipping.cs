using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Liskov
{
    public interface IShipping
    {
        decimal CalculateShippingCost(
            float packageWeightInKilograms,
            Size<float> packageDimensionInInches,
            RegionInfo destination);
    }
}
