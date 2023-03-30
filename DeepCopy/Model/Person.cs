using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepCopy.Model
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Score> Scores { get; set; }
        public override string ToString()
        {
            var str = $"Name:{Name} Age:{Age} \n";
            return Scores.Aggregate(str, (current, score) => current + score.ToString());
        }
    }
}
