using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace DotNetPowerOff
{
    public partial class Service1 : ServiceBase
    {

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            System.Timers.Timer t = new System.Timers.Timer(10000);//实例化Timer类，设置间隔时间为10000毫秒； 
            t.Elapsed += new System.Timers.ElapsedEventHandler(rebootsystem);//到达时间的时候执行事件； 
            t.AutoReset = true;//设置是执行一次（false）还是一直执行(true)； 
            t.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；  

        }
        public void rebootsystem(object source, System.Timers.ElapsedEventArgs e)
        {
            if (DateTime.Now.AddMinutes(90).Date > DateTime.Now.Date)
            {
                System.Diagnostics.Process.Start("shutdown", "/s /f /t 0");
            }
        }


        protected override void OnStop()
        {
        }
    }
}
