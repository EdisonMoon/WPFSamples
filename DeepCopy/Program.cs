using System;
using System.Collections.Generic;
using DeepCopy.Helper;
using DeepCopy.Model;

namespace DeepCopy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ClassRoom classRoom = new()
            {
                Name = "高三一班",
                Students = new List<Person>
                {

                    new()
                        {
                            Name = "张三",
                            Age = 18,
                            Scores = new List<Score>
                            {
                                new()
                                {
                                    Subject = "语文",
                                    ScoreValue = 90
                                },
                                new()
                                {
                                    Subject = "数学",
                                    ScoreValue = 80
                                }
                            }
                        },
                        new()
                        {
                            Name = "李四",
                            Age = 19,
                            Scores = new List<Score>
                            {
                                new()
                                {
                                    Subject = "语文",
                                    ScoreValue = 100
                                },
                                new()
                                {
                                    Subject = "数学",
                                    ScoreValue = 90
                                }
                            }
                        }
                    }

            };
            var classRoom3 = DeepCopyHelper.DeepClone(classRoom);
            classRoom3.Name = "高三二班";
            classRoom3.Students[0].Name = "王五";
            classRoom3.Students[0].Scores[0].ScoreValue = 100;
            Console.WriteLine(classRoom);
            Console.WriteLine(classRoom3);
            Console.ReadLine();
        }
    }
}
