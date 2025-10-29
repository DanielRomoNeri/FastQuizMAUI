using SQLite;
namespace FastQuizMAUI.Models
{
    [Table("ItemsBox")]
    public class ItemsBoxModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(250)]
        public string FrontText { get; set; }
        [MaxLength(250)]
        public string BackText { get; set; }
        public string Context{ get; set; }
        public int Level { get; set; }
        public int BoxId { get; set; }
    }
}
