namespace bca.Models
{
    public class Filme
    {
        public int Id { get; set; }
        public string Titlu { get; set; }
        public string Regizor { get; set; }
        public string Durata { get; set; }

        public ICollection<FilmActor> FilmActors { get; set; }

    }
}
