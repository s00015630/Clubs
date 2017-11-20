using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubsAndSocieties.Models
{
    public class Notification
    {
        public int Id { get; set; }

        public int AdminID { get; set; }


        public string Title { get; set; }


        public DateTime Date { get; set; }


        public string Message { get; set; }

        public virtual Administrator Administrator { get; set; }
    }

}