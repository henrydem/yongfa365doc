using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.IO;

namespace WindowsService1
{
    public partial class Service1 : ServiceBase
    {

        public Service1()
        {
            InitializeComponent();
            this.ServiceName = "启动成功或失败会显示这个名称";
        }

        protected override void OnStart(string[] args)
        {
            //系统服务只能使用这个timer而不能使用拖过来的
            System.Timers.Timer timer1 = new System.Timers.Timer();
            timer1.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Elapsed);
            timer1.Interval = 1000 * 2;
            timer1.Enabled = true;
        }

        protected override void OnStop()
        {

        }
        void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {

            #region 事件日志操作
            //不允许向Security里写数据

            #region 写到Application里
            {
                if (!EventLog.SourceExists("CrazyIIS_Application"))
                {
                    EventLog.CreateEventSource("CrazyIIS_Application", "Application");
                }

                EventLog log = new EventLog();
                log.Source = "CrazyIIS_Application";
                log.WriteEntry("柳永法提醒您，这是：CrazyIIS_Application", EventLogEntryType.FailureAudit);
                log.WriteEntry("柳永法提醒您，这是：CrazyIIS_Application", EventLogEntryType.Information);
                log.WriteEntry("柳永法提醒您，这是：CrazyIIS_Application", EventLogEntryType.Warning);
            }
            #endregion

            #region 写到System里
            {
                if (!EventLog.SourceExists("CrazyIIS_System"))
                {
                    EventLog.CreateEventSource("CrazyIIS_System", "System");
                }

                EventLog log = new EventLog();
                log.Source = "CrazyIIS_System";
                log.WriteEntry("柳永法提醒您，这是：CrazyIIS_System", EventLogEntryType.FailureAudit);
                log.WriteEntry("柳永法提醒您，这是：CrazyIIS_System", EventLogEntryType.Information);
                log.WriteEntry("柳永法提醒您，这是：CrazyIIS_System", EventLogEntryType.Warning);
            }
            #endregion



            // EventLog.Delete("我的软件");
            // EventLog.DeleteEventSource("CrazyIIS");

            if (!EventLog.SourceExists("CrazyIIS"))
            {
                EventLog.CreateEventSource("CrazyIIS", "我的软件");
            }


            EventLog myLog = new EventLog();
            myLog.Source = "CrazyIIS";
            myLog.WriteEntry("CrazyIIS", EventLogEntryType.Error, 12345, 22222);
            myLog.WriteEntry("CrazyIIS", EventLogEntryType.FailureAudit, 12345, 22222);
            #endregion
        }



    }
}
