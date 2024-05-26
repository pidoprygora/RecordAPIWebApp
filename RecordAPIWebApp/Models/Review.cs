namespace RecordAPIWebApp.Models
{
    public class Review
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }

        public int RecordId { get; set; }

        public string Image { get; set; }
    }
}
