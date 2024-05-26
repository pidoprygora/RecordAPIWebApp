using System.ComponentModel.DataAnnotations;

namespace RecordAPIWebApp.Models
{
    public class Artist
    {
        public Artist()
        {
            Records = new List<Record>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Years { get; set; }

        public virtual ICollection<Record> Records { get; set; }
    }
}
