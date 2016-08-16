﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }
            
        //[MustBe18ForMembership]
        public DateTime? BirthDate { get; set; }
        
        public byte MembershipTypeId { get; set; }
    }
}