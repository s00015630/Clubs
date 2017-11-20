using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubsAndSocieties.Models
{
    public class Post
    {
        public int Id { get; set; }

        public int StudentID { get; set; }

        public int EventID { get; set; }


        public DateTime? Date { get; set; }


        public string Title { get; set; }

        public string PostMessage { get; set; }

        public virtual Event Event { get; set; }

        public virtual Student Student { get; set; }
    }
}
