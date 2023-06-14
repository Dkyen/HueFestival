using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HueFestival.ViewModel
{
	public class AboutViewModel
	{
       
        public int AboutId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
    }
}

