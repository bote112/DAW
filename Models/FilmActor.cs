namespace bca.Models
{
    public class FilmActor
    {
        public int Id { get; set; }
        public int FilmId { get; set; }
        public int ActorId { get; set; }

        public Actori Actor { get; set; }
        public Filme Film { get; set; }
    }
}
