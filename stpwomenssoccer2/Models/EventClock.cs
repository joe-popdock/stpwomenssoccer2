using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace stpwomenssoccer2.Models
{
    [Table("EventClock")]
    public class EventClock
    {
        [DisplayName("Date")]
        public string Date { get; set; }
        [Key]
        [DisplayName("Event Title")]
        public string EventTitle { get; set; }
        public bool Expired { get; set; }
    }
}