using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;
using System.Xml.Serialization;
using YongFa365.Serialization;

namespace AboutSerializable
{
    public class SerializeXmlWithAttribute
    {
        public void Test()
        {
            Student student = new Student()
            {
                Code = 1,
                Age = 23,
                ComeIn = DateTime.Now,
                UserName = "张三",
                Scores = new List<StudentScore>()
                {
                    new StudentScore{ Code=1, Score=34.3m, CodeSpecified=true, Course="语言"},
                    new StudentScore{ Code=1, Score=50.4m, Course="化学"},//Score不会被序列化。
                    new StudentScore{ Code=1,Course=""},//Course为“”会显示这个结点<Course />，为null或不给值时不会显示结点
                }
            };


            string temp = SerializeHelper.ToXml3(student);
            Student student2 = SerializeHelper.FromXml<Student>(temp);

        }
    }




    //默认情况下，XML 元素名称由类或成员名称确定。在名为 Book 的简单类中，字段 ISBN 将生成 XML 元素标记 <ISBN>，
    //若要重新命名元素，可以更改这种默认行为。下面的代码演示特性如何通过设置 XmlElementAttribute 的 ElementName 属性实现此目的。

    [Serializable]
    public class Student
    {
        [XmlAttribute]//序列化成属性，反序列化时的xml也得是属性
        public int Code { get; set; }

        [XmlAttribute("学生姓名")]//序列化成属性，并改名为"学生姓名"
        public string UserName { get; set; }

        [XmlElement("年龄")] //序列化成元素，并改名为:"年龄"
        public int Age { get; set; }

        [XmlIgnore] //此特性表示：序列化及反序列化时忽略。
        public DateTime ComeIn { get; set; }

        [XmlArray("给Scores换名")]
        [XmlArrayItem("给Scores数组或list所表示的类换名")]
        public List<StudentScore> Scores { get; set; }

        [XmlElement("将List扁平化并且此为节点名")]
        public List<StudentScore> Scores { get; set; }
    }

    [Serializable]
    public class StudentScore
    {
        public int Code { get; set; }

        [XmlIgnore]
        public bool CodeSpecified { get; set; }//如果设置了Specified,则Specified==true时才会序列化属性Code

        public string Course { get; set; }

        public decimal Score { get; set; }
    }
}
