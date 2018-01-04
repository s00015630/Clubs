using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClubsAndSocieties.Models
{

    public class ClubEvents
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ClubID { get; set; }
        public int EventID { get; set; }

        public virtual Club Clubs { get; set; }
        public virtual Event Events { get; set; }

    }
}
