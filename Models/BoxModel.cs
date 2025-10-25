using SQLite;

namespace FastQuizMAUI.Models
{
    [Table("Box")]
    public class BoxModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(100), Unique]
        public string BoxName { get; set; }
        public string BoxDescription { get; set; }
    }
}
