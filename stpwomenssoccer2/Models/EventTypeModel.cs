using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace stpwomenssoccer2.Models
{
    [Table("EventType")]
    public class EventTypeModel
    {
        [Key]
        public int EventTypeId { get; set; }
        [DisplayName("EventTypeName")]
        public string EventTypeName { get; set; }

    }
}