using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;



namespace TestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [DataTestMethod]
        [DynamicData(nameof(GetDataFromJson.GetTestData),DynamicDataSourceType.Method)]
        public void TestMethod(string testCaseName, dynamic input, dynamic expectedOutput)
        {
            
        }
    }

    
}
