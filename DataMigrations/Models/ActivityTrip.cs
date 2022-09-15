using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMigrations.Models
{
    public class ActivityTrip
    {
        public int ActivityId { get; set; }
        public int TripId { get; set; }
        public Activity Activity { get; set; }
        public Trip Trip { get; set; }
        
    }
}
