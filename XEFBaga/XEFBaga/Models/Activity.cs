using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XEFBaga.Models
{
    public class Activity
    {
        [Key]
        public int ActivityId { get; set; }
        public string Name { get; set; }
        [ForeignKey("Trips")]
        public int TripId { get; set; }
        public HashSet<ActivityTrip> ActivityTrip { get; set; }
    }
}
