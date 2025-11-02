using SQLite;

namespace FastQuizMAUI.Data
{
    [Table("Box")]
    public class Box
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(100), Unique]
        public string BoxName { get; set; }
        public string BoxDescription { get; set; }
        public int BoxCategoryId { get; set; }
    }
}
