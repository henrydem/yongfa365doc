using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using YongFa365.Serialization;
using System.Xml.Schema;

namespace AboutSerializable
{
    public class SerializeXmlNoAttribute
    {
        public void Test()
        {
            Student2 student = new Student2()
            {
                Code = 1,
                Age = 23,
                ComeIn = DateTime.Now,
                UserName = "张三",
                Scores = new List<StudentScore2>()
                {
                    new StudentScore2{ Code=1, Score=34.3m, Course="语言"},
                    new StudentScore2{ Code=1, Score=50.4m, Course="化学"},
                    new StudentScore2{ Code=1,Course=""},
                }
            };

            SerializeHelper serial = new SerializeHelper();
            string temp = serial.ToXml3(student);
            Student student2 = serial.FromXml<Student>(temp);

        }
    }


    [Serializable]
    public class Student2
    {
        public int Code { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
        public DateTime ComeIn { get; set; }
        public List<StudentScore2> Scores { get; set; }
    }

    [Serializable]
    public class StudentScore2
    {
        public int Code { get; set; }
        public string Course { get; set; }
        public decimal Score { get; set; }
    }
}
