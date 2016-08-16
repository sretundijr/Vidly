using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a Valid Customer Name")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }

        //this field is required only if the customer wants to purchase a membership
        [Column(TypeName="Date")]
        [Display(Name = "Date of Birth")]
        [MustBe18ForMembership]
        public DateTime? BirthDate { get; set; }

        //entity will see this as a foriegn key
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}