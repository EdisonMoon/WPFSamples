using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject2
{
    public static class GetDataFromJson
    {
        public static IEnumerable<object[]> GetTestData()
        {
            using (StreamReader r = new StreamReader("test_cases.json"))
            {
                string json = r.ReadToEnd();
                var testCases = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(json);

                foreach (var testCase in testCases)
                {
                    yield return new object[] { testCase.Key, testCase.Value.input, testCase.Value.expected_output };
                }
            }
        }
    }
}
