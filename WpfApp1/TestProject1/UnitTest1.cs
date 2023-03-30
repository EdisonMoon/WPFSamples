using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using NUnit.Framework;

namespace TestProject1
{
    public class Tests
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public void Test_Multiply(int input1, int input2, int expectedResult)
        {
            // Arrange

            // Act
            var result = (input1*input2);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }


        private static IEnumerable<object[]> TestData()
        {
            var json = File.ReadAllText("test_cases.json");
            dynamic data = JsonConvert.DeserializeObject(json);

            foreach (var item in data)
            {
                yield return new object[]
                {
                    (int)item.input1,
                    (int)item.input2,
                    (int)item.expectedResult
                };
            }
        }


    }
}