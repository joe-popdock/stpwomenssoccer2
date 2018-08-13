using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace stpwomenssoccer2.Models
{
    [Table("Team")]
    public class TeamModel
    {
        [Key]
        public int TeamId { get; set; }
        [DisplayName("Team")]
        public string TeamName { get; set; }

    }
}