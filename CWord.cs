using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TextComparision
{
    public class CWord
    {
        /// <summary>
        /// This is the compared word
        /// </summary>
        public string Word { get; set; }

        /// <summary>
        /// This is the status of the compared word
        /// </summary>
        public ColoringEnum Color { get; set; }

        public CWord(string word, ColoringEnum color)
        {
            this.Word = word;   
            this.Color = color;
        }
    }
}
