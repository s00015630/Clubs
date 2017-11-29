using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClubsAndSocieties.Models
{
    public class Event
    {
        public int Id { get; set; }

        [ForeignKey("Club")]
        public int ClubID { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }


        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string Image { get; set; }

        // Need to add these to match the Db table in Azure
        public bool PrivateClubEvent { get; set; }
        public bool PublicClubEvent { get; set; }
        //public virtual Club Clubs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Post> Posts { get; set; }
    }
}
