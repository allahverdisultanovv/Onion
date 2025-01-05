namespace ProniaOnion.Domain.Entities
{
    public class Blog : BaseEntity
    {
        public string Title { get; set; }
        public string Article { get; set; }
        public string Image { get; set; }
        //relational
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public Author Author { get; set; }
        public Genre Genre { get; set; }

    }
}
