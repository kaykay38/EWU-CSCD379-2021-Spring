﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecretSanta.Web.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = "";
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = "";

        public List<GiftViewModel> Gifts;

        [Required]
        [Display(Name="Group")]
        public string GroupName { get; set; }

        public string FullName => $"{FirstName} {LastName}";
        
    }
}
