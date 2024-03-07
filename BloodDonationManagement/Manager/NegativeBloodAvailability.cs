using BloodDonationManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationManagement.Manager
{
    public class NegativeBloodAvailability : IBloodAvailability
    {
        public string Availability()
        {
            return "Negative blood types are less common and may be harder to find.";
        }
    }
}
