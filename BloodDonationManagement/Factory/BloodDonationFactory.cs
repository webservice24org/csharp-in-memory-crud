using BloodDonationManagement.Manager;
using BloodDonationManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationManagement.Factory
{
    public class BloodDonationFactory
    {
        public static BloodDonationManager CreateManager()
        {
            IBloodDonationRepository repository = new BloodDonationRepository();
            return new BloodDonationManager(repository);
        }
    }
}
