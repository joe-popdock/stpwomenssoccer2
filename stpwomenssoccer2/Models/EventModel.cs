using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace stpwomenssoccer2.Models
{
    [Table("Event")]
    public class EventModel
    {
        [Key]
        [DisplayName("ID")]
        public int EventId { get; set; }
        [DisplayName("Event Type")]
        public int EventTypeId { get; set; }
        public IEnumerable<EventTypeModel> EventTypes { get; set; }
        [DisplayName("Date")]
        public string Date { get; set; }
        [DisplayName("Time")]
        public string Time { get; set; }
        [DisplayName("Event Name")]
        public string EventName { get; set; }
        [DisplayName("Location")]
        public string Location { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }
        [DisplayName("Team")]
        public int TeamId { get; set; }
        public IEnumerable<TeamModel> Teams { get; set; }
        [DisplayName("Result")]
        public string Result { get; set; }
        public bool Expired { get; set; }
    }
}