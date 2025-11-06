using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastQuizMAUI.Models
{
    public class OptionsModel
    {
        public int QuizMode { get; set; }
        public int Order { get; set; }
        public int Qty { get; set; }
        public bool ShowContext { get; set; }
        public ItemsBoxModel[]? Items { get; set; } 

    }
}
