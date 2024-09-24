using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealBridgeModels.Models
{
    public class Feedback
    {
        [Key]
        public int FeedbackId { get; set; }       

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        public string Comment { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation propertie
       
        [ForeignKey("FkDonorId")]
        public User Donor { get; set; }
        public int? FkDonorId { get; set; }

        [ForeignKey("FkRecipientId")]
        public User Recipient { get; set; }
        public int? FkRecipientId { get; set; }

        [ForeignKey("FkRecipientId")]
        public Donation Donation { get; set; }
        public int? FkDonationId { get; set; }

    }
}
