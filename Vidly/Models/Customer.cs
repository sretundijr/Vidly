using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipType MembershipType { get; set; }

        [Column(TypeName="Date")]
        public DateTime? BirthDate { get; set; }
        //entity will see this as a foriegn key
        public byte MembershipTypeId { get; set; }
    }
}