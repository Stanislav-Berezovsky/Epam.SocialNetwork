using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialNetwork.ViewsModels
{
    public class EditingViewModel
    {
        public int UserId { get; set; }
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Uncorrect email")]
        public string UserEmail { get; set; }


        [Display(Name = "Enter your first name*")]
        [Required(ErrorMessage = "The field can not be empty!")]
        public string UserName { get; set; }


        [Display(Name = "Enter your last name")]
        public string UserSurname { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Enter your birthday date")]
        public DateTime? UserBirthDate { get; set; }

        
        [Display(Name = "Password*")]
        [StringLength(100, ErrorMessage = "The password must contain at least {2} characters", MinimumLength = 4)]
        [DataType(DataType.Password)]
        public string OldUserPassword { get; set; }

       
        [Display(Name = "Password*")]
        [StringLength(100, ErrorMessage = "The password must contain at least {2} characters", MinimumLength = 4)]
        [DataType(DataType.Password)]
        public string NewUserPassword { get; set; }

        
        [DataType(DataType.Password)]
        [Compare("NewUserPassword", ErrorMessage = "Passwords must match")]
        public string ConfirmPassword { get; set; }

    }
}