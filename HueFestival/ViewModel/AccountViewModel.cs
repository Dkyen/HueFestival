using System;
using System.ComponentModel.DataAnnotations;

namespace HueFestival.ViewModel
{
	public class AccountViewModel
	{
        public int AccountId { get; set; }

        public string? Username { get; set; }

        public string? Password { get; set; }

        public string? Email { get; set; }
        
        public int PhoneNumber { get; set; }

        public int Role { get; set; }
    }

    public class AccountViewModel_Create

    {
        public string? Username { get; set; }

        public string? Password { get; set; }

        public string? Email { get; set; }

        public int PhoneNumber { get; set; }

        public int Role { get; set; }
    }

}

