namespace Restaurent.Models
{
    public class BookATable
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public int TableId { get; set; }
        public string? NumberOfPeople { get; set; }
        public DateTime Time { get; set; }
    }
}
