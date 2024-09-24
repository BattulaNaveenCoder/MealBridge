using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealBridgeModels.Models
{
    public class Token
    {
        [Key]
        public int TokenId { get; set; }

        [Required]
        [MaxLength(100)]
        public string TokenCode { get; set; }

        public TokenStatus Status { get; set; } = TokenStatus.Active; // Enum

        public DateTime IssuedAt { get; set; } = DateTime.UtcNow;

        public DateTime? ClaimedAt { get; set; }


        //Navigation Properties
        public int? FkDonationId { get; set; }
        [ForeignKey("FkDonationId")]
        public Donation Donation { get; set; }


        public int? FkRecipientId { get; set; }
        [ForeignKey("FkRecipientId")]
        public Recipient Recipient { get; set; }

    }
    public enum TokenStatus
    {
        Active,
        Used,
        Expired
    }
}
