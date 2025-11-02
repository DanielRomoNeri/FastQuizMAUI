using System.Linq.Expressions;
using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;
namespace FastQuizMAUI.Models
{
    [Table("ItemsBox")]
    public partial class ItemsBoxModel : ObservableObject
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(300)]
        public string FrontText { get; set; }
        [MaxLength(300)]
        public string BackText { get; set; }
        public string Context{ get; set; }
        public int Level { get; set; } = 30;
        public int BoxId { get; set; }
        public bool IsEnabled { get; set; }

        private bool _isSelected = false;

        [Ignore] 
        public bool isSelected
        {
            get => _isSelected;
          
            set => SetProperty(ref _isSelected, value);
        }

    }
}
