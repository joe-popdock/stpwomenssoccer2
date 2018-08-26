using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace stpwomenssoccer2.Models
{
    [Table("UpcomingEvent")]
    public class UpcomingEvent
    {
        [Key]
        public int CardId { get; set; }
        public string CardDate { get; set; }
        public string CardTitle { get; set; }
        public bool Expired { get; set; }
    }
}