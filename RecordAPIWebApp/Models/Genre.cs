using System.ComponentModel.DataAnnotations;

namespace RecordAPIWebApp.Models
{
    public class Genre
    {
        public Genre()
        {
            Records = new List<Record>();
        } 

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Record> Records { get; set; }
    }
}
