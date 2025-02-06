namespace MediaLibrary.Server.Data
{
    public class Person : BaseEntity
    {
        public DateTime BirthDay { get; set; }
        public string BirthPlace { get; set; }
        public string Biography { get; set; }
        public List<MovieActor> Movies { get; set; } = new List<MovieActor>();
    }
}
