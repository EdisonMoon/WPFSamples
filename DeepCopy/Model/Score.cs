using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepCopy.Model
{
    public class Score
    {
        public string Subject { get; set; }
        public int ScoreValue { get; set; }

        public override string ToString()
        {
            return $"Subject:{Subject} ScoreValue:{ScoreValue} \n";
        }
    }
}
