using BloodDonationManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationManagement.Repository
{
    public class BloodDonationRepository : IBloodDonationRepository
    {
        private List<BloodDonation> _donations;

        public BloodDonationRepository()
        {
            _donations = new List<BloodDonation>();
        }

        public BloodDonation GetById(int id)
        {
            return _donations.Find(d => d.Id == id);
        }

        public void Add(BloodDonation donation)
        {
            _donations.Add(donation);
        }

        public void Update(BloodDonation donation)
        {
            BloodDonation existingDonation = GetById(donation.Id);
            if (existingDonation != null)
            {
                existingDonation.DonorName = donation.DonorName;
                existingDonation.BloodType = donation.BloodType;
                existingDonation.DonationDate = donation.DonationDate;
            }
        }

        public void Delete(int id)
        {
            _donations.RemoveAll(d => d.Id == id);
        }

        public IEnumerable<BloodDonation> GetAll()
        {
            return _donations;
        }
    }
}
