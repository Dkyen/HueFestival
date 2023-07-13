using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HueFestival.ViewModel
{
	public class AboutViewModel
	{
       
        public int AboutId { get; set; }
        public string? Title { get; set; }
        
    }

    public class AboutViewModel_Add
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
    }

    public class AboutViewModel_Details
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
    }
}

