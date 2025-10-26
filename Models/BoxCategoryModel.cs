using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace FastQuizMAUI.Models
{
    [Table("BoxCategory")]
    public class BoxCategoryModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Category { get; set; }

    }
}
