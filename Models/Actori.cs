namespace bca.Models
{
    public class Actori
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string DataNasterii { get; set; }

        public ICollection<FilmActor> FilmActors { get; set; }

    }
}
