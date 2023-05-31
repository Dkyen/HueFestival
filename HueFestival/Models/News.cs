namespace HueFestival.Controllers
{
    public class News
    {
        public int NewsId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Image { get; set; }
        public DateTime CreatedAt { get; set; }
        
    }
}
