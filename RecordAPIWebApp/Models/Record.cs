using System.ComponentModel.DataAnnotations;

namespace RecordAPIWebApp.Models
{
    public class Record
    {
        public Record() 
        {
            Reviews = new List<Review>();
        }

        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public int ArtistId { get; set; }
        
        public int Year { get; set; }

        public int GenreId { get; set; }

        public string Image { get; set; }

        public int ReviewId { get; set; }

        public virtual ICollection<Review> Reviews { get; set;}

    }
}
