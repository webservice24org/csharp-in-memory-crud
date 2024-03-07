using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationManagement.Entities
{
    public class Donor
    {
        public string Name { get; set; }
        public string Contact { get; set; }
    }

    public static class DefaultDonors
    {
        public static readonly Dictionary<BloodType, List<Donor>> DefaultDonorsList = new Dictionary<BloodType, List<Donor>>
        {
            { BloodType.APositive, new List<Donor> { new Donor { Name = "John", Contact = "1234567890" }, new Donor { Name = "Alice", Contact = "9876543210" } } },
            { BloodType.ANegative, new List<Donor> { new Donor { Name = "Bob", Contact = "5551234567" }, new Donor { Name = "Eve", Contact = "5559876543" } } },
        };
    }
}
