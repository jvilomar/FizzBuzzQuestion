using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WillDom.TechDemo.Interfaces;

namespace WillDom.TechDemo.Models
{
    public class WordexInfo : IWordexInfo
    {
        public int Multiple { get; set; }
        public int Multiplier { get; set; }
        public string Word { get; set; }
    }
}
