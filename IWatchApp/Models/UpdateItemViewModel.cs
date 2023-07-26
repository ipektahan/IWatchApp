namespace IWatchApp.Models
{
    public class UpdateItemViewModel
    {
        public Guid Id { get; set; }
        public string Type { get; set; }

        public string URL { get; set; }

        public long Price { get; set; }

        public DateTime DateofStart { get; set; }

        public DateTime DateofEnd { get; set; }
    }
}
