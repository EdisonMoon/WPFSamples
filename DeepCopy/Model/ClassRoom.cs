using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DeepCopy.Model
{
    public class ClassRoom
    {
        public string Name { get; set; }
        public List<Person> Students { get; set; }
        public override string ToString()
        {
            var str = $"Name:{Name} \n";

            return Students.Aggregate(str, (current, student) => current + student.ToString());

        }
    }
}
