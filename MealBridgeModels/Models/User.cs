using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealBridgeModels.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get;set; }

        [Required]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(250)]
        public string Password { get; set; }

        [Required]
        public UserType UserType { get; set; } // Enum

        public string Address { get; set; }

        public DateTime createdAt { get;set;}=DateTime.UtcNow;
        public DateTime updatedAt { get; set; }=DateTime.UtcNow;

        public ICollection<Donation> Donations { get; set; }
        public ICollection<Recipient> Recipients { get; set; }
      

    }
    public enum UserType
    {
        Donor,
        Recipient,
        Volunteer
    }
}
