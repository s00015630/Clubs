using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubsAndSocieties.Models
{
    public class Administrator
    {
        public int Id { get; set; }


        public string Name { get; set; }


        public string Password { get; set; }


        public virtual ICollection<Club> Clubs { get; set; }


        public virtual ICollection<Notification> Notifications { get; set; }

    }
}