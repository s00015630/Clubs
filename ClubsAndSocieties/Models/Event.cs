using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubsAndSocieties.Models
{
    public class Event
    {
        public int Id { get; set; }


        public string Title { get; set; }

        public string Description { get; set; }


        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string Image { get; set; }

        // Need to add these to match the Db table in Azure
        public bool PrivateClubEvent { get; set; }
        public bool PublicClubEvent { get; set; } 
        public virtual ICollection<ClubEvent> ClubEvents { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Post> Posts { get; set; }
    }
}
