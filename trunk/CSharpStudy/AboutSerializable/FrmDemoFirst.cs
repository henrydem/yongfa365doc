using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Diagnostics;

namespace AboutSerializable
{
    public partial class FrmDemoFirst : Form
    {
        public FrmDemoFirst()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
    

            CodeTimer.Time("JSON",        100, new TestJSON());
            CodeTimer.Time("XML",         10000, new TestXML());
            CodeTimer.Time("Bin",         10000, new TestBin());
            CodeTimer.Time("TestSoap",    10000, new TestSoap());
            //StringBuilder strBuilder = new StringBuilder();
            //XmlSerializer xmlSerler = new XmlSerializer(typeof(Users));

            //XmlWriter sw = XmlWriter.Create(strBuilder);

            ////序列化
            //xmlSerler.Serialize(sw, users);
            //MessageBox.Show(strBuilder.ToString());

            ////反序列化
            //Users user2 = xmlSerler.Deserialize(new StringReader(strBuilder.ToString())) as Users;

            //MessageBox.Show(string.Format("Id{0},username{1},islive{2}", user2.Id, user2.UserName, user2.IsLive));
        }
    }

    public class TestJSON : IAction
    {
        #region IAction Members

        public void Action()
        {
            Users user = new Users();
            user.Id = 12;
            user.UserName = @"柳

"",'[]
永法"; 
            user.IsLive = true;



            Common.Serialization.SerializeHelper helper = new Common.Serialization.SerializeHelper();

            string aaa = helper.ToJson(user);
            File.AppendAllText("json.txt", aaa);
        }

        #endregion
    }


    public class TestXML : IAction
    {
        #region IAction Members

        public void Action()
        {
            Users user = new Users();
            user.Id = 12;
            user.UserName = @"柳

"",'[]
永法";
            Common.Serialization.SerializeHelper helper = new Common.Serialization.SerializeHelper();

            string aaa = helper.ToXml(user);
            File.AppendAllText("XML.txt", aaa);
        }

        #endregion
    }

    public class TestBin : IAction
    {
        #region IAction Members

        public void Action()
        {
            Users user = new Users();
            user.Id = 12;
            user.UserName = @"柳

"",'[]
永法";

            Common.Serialization.SerializeHelper helper = new Common.Serialization.SerializeHelper();

            string aaa = helper.ToBinary(user);
            File.AppendAllText("bin.txt", aaa);
        }

        #endregion
    }

    public class TestSoap : IAction
    {
        #region IAction Members

        public void Action()
        {
            Users user = new Users();
            user.Id = 12;
            user.UserName = @"柳

"",'[]
永法";
            user.IsLive = true;
            Common.Serialization.SerializeHelper helper = new Common.Serialization.SerializeHelper();

            string aaa = helper.ToSoap(user);
            File.AppendAllText("soap.txt", aaa);
        }

        #endregion
    }


    public class Users
    {
        public int Id;
        public string UserName { get; set; }
        public bool IsLive { get; set; }
    }
}
