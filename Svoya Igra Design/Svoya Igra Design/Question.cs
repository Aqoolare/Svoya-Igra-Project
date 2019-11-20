using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svoya_Igra_Design
{
    [Serializable]
    public class Question
    {
        public string Content { get; set; }
        public string Answer { get; set; }
        public bool Checked { get; set; }
        public Question() 
        {
            Checked = false;
        }
    }
}
