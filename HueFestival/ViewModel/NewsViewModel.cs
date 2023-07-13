using System;
namespace HueFestival.ViewModel
{
	public class NewsViewModel
	{
        public int NewsId { get; set; }
        public string? Title { get; set; }
    
    }

    public class NewsViewModel_Add
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Image { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class NewsViewModel_Details
    {
        public int NewsId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Image { get; set; }
        public DateTime CreatedAt { get; set; }


    }
}


