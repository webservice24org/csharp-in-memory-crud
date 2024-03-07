using BloodDonationManagement.Entities;
using BloodDonationManagement.Factory;
using BloodDonationManagement.Manager;
using BloodDonationManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationManagement
{
    internal class Program
    {
        private static BloodDonationManager manager;

        static void Main(string[] args)
        {
            try
            {
                manager = BloodDonationFactory.CreateManager();
                DoTask();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }

        private static void DoTask()
        {
            Console.WriteLine("\t\t\t\tBlood Donation Management\r");
            Console.WriteLine("\t\t\t\t--------------------\n");
            Console.WriteLine("\t\tHow many operations would you like to perform?\n");
            int count = Convert.ToInt32(Console.ReadLine());
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine("\t\t\t\tSelect Operation\n");
                    Console.WriteLine("\t\tHint: \nSelect -1\nInsert -2\nUpdate -3\nDelete -4");
                    int opeCount = Convert.ToInt32(Console.ReadLine());
                    switch (opeCount)
                    {
                        case 1: ShowDonation("Show Donation", null); break;
                        case 2: InsertDonation(); break;
                        case 3: UpdateDonation(); break;
                        case 4: DeleteDonation(); break;
                    }
                }
            }
        }



        private static void DeleteDonation()
        {
            Console.WriteLine("Enter the ID of the donation to delete:");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                BloodDonation deletedDonation = manager.GetDonationById(id);
                manager.DeleteDonation(id);
                Console.WriteLine("Donation deleted successfully.");

                if (deletedDonation != null)
                {
                    Console.WriteLine("Deleted Donation Details:");
                    ShowDonation("Deleted Donation", deletedDonation);
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid ID.");
            }
        }

        private static void UpdateDonation()
        {
            Console.WriteLine("Enter the ID of the donation to update:");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                BloodDonation existingDonation = manager.GetDonationById(id);
                if (existingDonation != null)
                {
                    Console.WriteLine("Enter the updated donor name:");
                    string donorName = Console.ReadLine();

                    Console.WriteLine("Enter the updated blood type (APositive, ANegative, BPositive, BNegative, ABPositive, ABNegative, OPositive, ONegative):");
                    if (Enum.TryParse(Console.ReadLine(), out BloodType bloodType))
                    {

                        BloodDonation oldDonation = new BloodDonation(existingDonation.Id, existingDonation.DonorName, existingDonation.BloodType, existingDonation.DonationDate, existingDonation.BloodAvailability);

                        existingDonation.DonorName = donorName;
                        existingDonation.BloodType = bloodType;
                        manager.UpdateDonation(existingDonation);
                        Console.WriteLine("Donation updated successfully.");

                        Console.WriteLine("Old Donation Details:");
                        ShowDonation("Old Donation", oldDonation);
                        Console.WriteLine("Updated Donation Details:");
                        ShowDonation("Updated Donation", existingDonation);
                    }
                    else
                    {
                        Console.WriteLine("Invalid blood type.");
                    }
                }
                else
                {
                    Console.WriteLine("Donation not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid ID.");
            }
        }

        private static void InsertDonation()
        {
            Console.WriteLine("Enter the donor name:");
            string donorName = Console.ReadLine();

            Console.WriteLine("Select the blood type:");
            Console.WriteLine("1. APositive");
            Console.WriteLine("2. ANegative");
            Console.WriteLine("3. BPositive");
            Console.WriteLine("4. BNegative");
            Console.WriteLine("5. ABPositive");
            Console.WriteLine("6. ABNegative");
            Console.WriteLine("7. OPositive");
            Console.WriteLine("8. ONegative");

            if (int.TryParse(Console.ReadLine(), out int bloodTypeChoice))
            {
                BloodType bloodType;
                switch (bloodTypeChoice)
                {
                    case 1:
                        bloodType = BloodType.APositive;
                        break;
                    case 2:
                        bloodType = BloodType.ANegative;
                        break;
                    case 3:
                        bloodType = BloodType.BPositive;
                        break;
                    case 4:
                        bloodType = BloodType.BNegative;
                        break;
                    case 5:
                        bloodType = BloodType.ABPositive;
                        break;
                    case 6:
                        bloodType = BloodType.ABNegative;
                        break;
                    case 7:
                        bloodType = BloodType.OPositive;
                        break;
                    case 8:
                        bloodType = BloodType.ONegative;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid blood type.");
                        return;
                }

                IBloodAvailability bloodAvailability;
                if (bloodType == BloodType.ANegative || bloodType == BloodType.BNegative || bloodType == BloodType.ABNegative || bloodType == BloodType.ONegative)
                {
                    bloodAvailability = new NegativeBloodAvailability();
                }
                else
                {
                    bloodAvailability = new PositiveBloodAvailability();
                }

                BloodDonation newDonation = new BloodDonation(manager.GetAllDonations().Count() + 1, donorName, bloodType, DateTime.Now, bloodAvailability);

                manager.AddDonation(newDonation);
                Console.WriteLine("Donation added successfully.");

                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("|              Donation Details Table               |");
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("|   ID   |   Donor Name   |   Blood Type   |   Date   |");
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine($"|   {newDonation.Id}   |   {newDonation.DonorName}   |   {newDonation.BloodType}   |   {newDonation.DonationDate}   |");
                Console.WriteLine("-----------------------------------------------------");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number corresponding to the blood type.");
            }
        }




        private static void ShowDonation(string label, BloodDonation donation)
        {
            if (donation != null)
            {
                Console.WriteLine($"{label}: ID: {donation.Id}, Donor Name: {donation.DonorName}, Blood Type: {donation.BloodType}, Donation Date: {donation.DonationDate}");
                Console.WriteLine($"Blood Availability: {donation.BloodAvailability.Availability()}");


                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("|              Donation Details Table               |");
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("|   ID   |   Donor Name   |   Blood Type   |   Date   |");
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine($"|   {donation.Id}   |   {donation.DonorName}   |   {donation.BloodType}   |   {donation.DonationDate}   |");
                Console.WriteLine("-----------------------------------------------------");
            }
            else if (label == "Show Donation")
            {
                Console.WriteLine("Default Donations:");
                foreach (var bloodType in DefaultDonors.DefaultDonorsList)
                {
                    Console.WriteLine($"Blood Type: {bloodType.Key}");
                    foreach (var donor in bloodType.Value)
                    {
                        Console.WriteLine($"Name: {donor.Name}, Contact: {donor.Contact}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid donation.");
            }
        }




    }


}
