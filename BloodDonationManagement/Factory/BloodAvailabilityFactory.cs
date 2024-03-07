using BloodDonationManagement.Manager;
using BloodDonationManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationManagement.Factory
{
    public static class BloodAvailabilityFactory
    {
        public static IBloodAvailability CreateBloodAvailability(string bloodType)
        {
            if (bloodType.StartsWith("A") || bloodType.StartsWith("B") || bloodType.StartsWith("AB") || bloodType == "OPositive")
            {
                return new PositiveBloodAvailability();
            }
            else if (bloodType.EndsWith("Negative"))
            {
                return new NegativeBloodAvailability();
            }
            else
            {
                throw new ArgumentException("Invalid blood type.");
            }
        }
    }

}
