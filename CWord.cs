using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextComparision
{
    internal class CWord
    {
        private String word;
        private CColoring color;

        public CWord(String word, CColoring color)
        {
            this.word = word;   
            this.color = color;
        }

        public String Word
        {
            get { return word; }
            set { this.word = value; }
        }

        public CColoring Color
        {
            get { return color; }
            set { this.color = value; }
        }
    }
}
