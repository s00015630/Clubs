using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubsAndSocieties.Models
{
    public class ClubEvent
    {
        public int Id { get; set; }

        public int ClubID { get; set; }

        public int EventID { get; set; }

        public virtual Club ClubsAndSociety { get; set; }

        public virtual Event Event { get; set; }
    }
}
