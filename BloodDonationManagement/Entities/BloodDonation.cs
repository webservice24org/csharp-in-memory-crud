using BloodDonationManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationManagement.Entities
{



    public class BloodDonation
    {
        public int Id { get; set; }
        public string DonorName { get; set; }
        public BloodType BloodType { get; set; }
        public DateTime DonationDate { get; set; }
        public IBloodAvailability BloodAvailability { get; set; }

        public BloodDonation() { }
        public BloodDonation(int id, string donorName, BloodType bloodType, DateTime donationDate, IBloodAvailability bloodAvailability)
        {
            Id = id;
            DonorName = donorName;
            BloodType = bloodType;
            DonationDate = donationDate;
            BloodAvailability = bloodAvailability;
        }
    }


}
