using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FizzBuzzQ.TechDemo.Common;
using FizzBuzzQ.TechDemo.Models;

namespace FizzBuzzQ.TechDemo.Common
{
    public class Wordex
    {
        private Operations _operations;

        public Wordex()
        {
            _operations = new Operations();
        }

        public List<string> GetWordex(int input)
        {
            var result = new List<string>();
            var word = string.Empty;

            for (int i = 1; i <= input; i++)
            {
                word = _operations.GetWord(new WordexInfo { Multiple = i, Multiplier = 3, Word = "Fizz" }) + "" +
                       _operations.GetWord(new WordexInfo { Multiple = i, Multiplier = 5, Word = "Buzz" }) + "" +
                       _operations.GetWord(new WordexInfo { Multiple = i, Multiplier = 7, Word = "Jazz" }) + "";

                result.Add(String.IsNullOrEmpty(word) ? i.ToString() : word);
            }
            return result;
        }
    }
}
