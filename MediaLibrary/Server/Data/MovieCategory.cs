using MediaLibrary.Shared;

namespace MediaLibrary.Server.Data
{
    public class MovieCategory
    {
        public int MovieId { get; set; }
        public Movie? Movie { get; set; }
        public CategoryType Category { get; set; }
    }
}
