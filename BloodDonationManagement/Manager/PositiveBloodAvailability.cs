using BloodDonationManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationManagement.Manager
{
    public class PositiveBloodAvailability : IBloodAvailability
    {
        public string Availability()
        {
            return "Positive blood types are readily available.";
        }
    }
}
