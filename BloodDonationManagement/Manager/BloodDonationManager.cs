using BloodDonationManagement.Entities;
using BloodDonationManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationManagement.Manager
{
    public class BloodDonationManager
    {
        private IBloodDonationRepository _repository;

        public BloodDonationManager(IBloodDonationRepository repository)
        {
            _repository = repository;
        }

        public void AddDonation(BloodDonation donation)
        {
            _repository.Add(donation);
        }

        public void UpdateDonation(BloodDonation donation)
        {
            _repository.Update(donation);
        }

        public void DeleteDonation(int id)
        {
            _repository.Delete(id);
        }

        public BloodDonation GetDonationById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<BloodDonation> GetAllDonations()
        {
            return _repository.GetAll();
        }
    }
}
