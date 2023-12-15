namespace IWatchApp.Models.Domain
{
    public class URL
    {
        public int URLId { get; set; }
        public string Link { get; set; }


        public Guid ID { get; set; }
        public Item Item { get; set; }
    }
}
