using System.ComponentModel.DataAnnotations;

namespace VOSG_NKBD.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        [DataType(DataType.Date)]// This annotation ensures that the only date part is considered, ignoring the time component.
        public DateTime ReleaseYear { get; set; }

        public string Producer { get; set; }
    }
}
