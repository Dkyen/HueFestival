using System;
using System.ComponentModel.DataAnnotations;

namespace HueFestival.ViewModel
{
    public class UserViewModel
    {
       
        public string? UserId { get; set; }

        [StringLength(255)]
        public string? Email { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Password { get; set; }

        public string? Role { get; set; }
    }

    public class RegisterInputModel
    {

        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        public string? ConfirmedPassword { get; set; }
    }

    public class LoginInputModel
    {
        [EmailAddress]
        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }


    public class UserChangeRoleInputModel
    {
        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Role { get; set; }
    }
    public class UserUpdate
    {

        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }
    }



}