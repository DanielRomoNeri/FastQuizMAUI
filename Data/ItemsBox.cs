using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;
namespace FastQuizMAUI.Data
{
    [Table("ItemsBox")]
    public partial class ItemsBox : ObservableObject
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(300)]
        public string FrontText { get; set; }
        [MaxLength(300)]
        public string BackText { get; set; }
        public string Context{ get; set; }
        public int Level { get; set; }
        public bool isEnabled { get; set; }
        public int BoxId { get; set; }


    }
}
