using BloodDonationManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationManagement.Repository
{
    public interface IBloodDonationRepository
    {
        BloodDonation GetById(int id);
        void Add(BloodDonation donation);
        void Update(BloodDonation donation);
        void Delete(int id);
        IEnumerable<BloodDonation> GetAll();
    }
}
