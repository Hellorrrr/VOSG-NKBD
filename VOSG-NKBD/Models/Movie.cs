using System.ComponentModel.DataAnnotations;

namespace VOSG_NKBD.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseYear { get; set; }

        public string Producer { get; set; }
    }
}
