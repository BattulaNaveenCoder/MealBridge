using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealBridgeModels.Models
{
    public class Donation
    {
        [Key]
        public int DonationId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FoodType { get; set; }

        [Required]
        public int MealCount { get; set; }

        [Required]
        public DonationType DonationType { get; set; } // Enum

        [Required]
        [MaxLength(255)]
        public string PickupLocation { get; set; }

        [Required]
        public decimal Latitude { get; set; }

        [Required]
        public decimal Longitude { get; set; }

        [Required]
        public DateTime PickupTime { get; set; }

        [Required]
        public DateTime AvailableUntil { get; set; }

        public DonationStatus Status { get; set; } = DonationStatus.Available; 

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


        //Navigation Properties
        [ForeignKey("FkDonorId")]
        public User Donor { get; set; }
        public int? FkDonorId { get; set; }

        public ICollection<Recipient> Recipients { get; set; }
        public ICollection<Token> Tokens { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
       
    }
    public enum DonationType
    {
        Surplus,
        Annadhanam,
        Event
    }

    public enum DonationStatus
    {
        Available,
        Claimed,
        Expired
    }
}
