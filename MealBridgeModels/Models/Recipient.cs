using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealBridgeModels.Models
{
    public class Recipient
    {
        [Key]
        public int RecipientId { get; set; }
        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;


        //Navigation Properties
        [ForeignKey("FkDonationId")]
        public Donation Donation { get; set; }
        public int? FkDonationId { get;set; }

        [ForeignKey("FkUserId")]
        public User User { get; set; }
        public int? FkUserId { get; set; }


        public ICollection<Token> Tokens { get; set; }
    }
}
