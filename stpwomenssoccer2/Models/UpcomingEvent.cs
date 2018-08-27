using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace stpwomenssoccer2.Models
{
    [Table("UpcomingEvent")]
    public class UpcomingEvent
    {
        [Key]
        [DisplayName("ID")]
        public int CardId { get; set; }
        [DisplayName("Card Date")]
        public string CardDate { get; set; }
        [DisplayName("Card Title")]
        public string CardTitle { get; set; }
        [DisplayName("Expired")]
        public bool Expired { get; set; }
    }
}