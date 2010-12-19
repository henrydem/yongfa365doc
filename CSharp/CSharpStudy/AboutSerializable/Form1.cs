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

using YongFa365.Serialization;


namespace AboutSerializable
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //CodeTimer.Time("JSON", 100, new TestJSON());
            //CodeTimer.Time("XML", 10000, new TestXML());
            //CodeTimer.Time("Bin", 10000, new TestBin());
            //CodeTimer.Time("TestSoap", 10000, new TestSoap());

            //在相关位置设置断点看效果
        }

        private void btnXML_Click(object sender, EventArgs e)
        {
            SerializeXmlNoAttribute serial = new SerializeXmlNoAttribute();
            serial.Test();
        }

        private void btnXML2_Click(object sender, EventArgs e)
        {
            SerializeXmlWithAttribute serial = new SerializeXmlWithAttribute();
            serial.Test();

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



            YongFa365.Serialization.SerializeHelper helper = new YongFa365.Serialization.SerializeHelper();

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
            YongFa365.Serialization.SerializeHelper helper = new YongFa365.Serialization.SerializeHelper();

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

            YongFa365.Serialization.SerializeHelper helper = new YongFa365.Serialization.SerializeHelper();

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
            YongFa365.Serialization.SerializeHelper helper = new YongFa365.Serialization.SerializeHelper();

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
