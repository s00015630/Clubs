using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClubsAndSocieties.Models
{
    public class Club
    {

        public int Id { get; set; }
        [Required()]
        public int AdministratorID { get; set; }
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        [Required()]
        public string Name { get; set; }
        [StringLength(30, ErrorMessage = "Cannot be longer than 30 characters.")]
        [Required()]
        public string Chairperson { get; set; }
        [StringLength(30, ErrorMessage = "Cannot be longer than 30 characters.")]
        [Required()]
        public string Secretary { get; set; }
        [StringLength(30, ErrorMessage = "Cannot be longer than 30 characters.")]
        [Required()]
        public string Treasurer { get; set; }
        [DataType(DataType.PhoneNumber, ErrorMessage = "Must be a phone number")]
        [Required()]
        public string Phone { get; set; }

        [Required()]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Description { get; set; }

        public virtual Administrator Administrator { get; set; }

        public virtual ICollection<Member> Members { get; set; }
    }
}
