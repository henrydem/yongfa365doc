using System;
using System.Diagnostics;

namespace AboutTraceDebug
{
    class Program
    {
        static void Main(string[] args)
        {
            DebugTest();
            TraceTest();
            ConditionalAttributeTest();
        }

        private static void DebugTest()
        {
            Debug.Print("我是yongfa{0}", 365);
            Debug.WriteLine(new { UserName = "yongfa365", Password = DateTime.Now });
            Debug.Assert(false);
        }

        private static void TraceTest()
        {
            //Trace.Listeners.Clear();
            //Trace.Listeners.Add(new DefaultTraceListener());
            //Trace.Listeners.Add(new ConsoleTraceListener());
            //Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            //Trace.Listeners.Add(new TextWriterTraceListener("dddddddddddddddddddddddddd.txt"));
            //Trace.Listeners.Add(new XmlWriterTraceListener("dddddddddddddddddddddddddd.xml"));
            //Trace.Listeners.Add(new EventLogTraceListener("Application"));
            Trace.WriteLine("\r\n\r\nStart\r\n\r\n");

            Trace.AutoFlush = true;
            Trace.IndentSize = 2;
            Trace.IndentLevel = 2;

            Trace.WriteLine("各种消息测试:");
            Trace.Indent();
            Trace.TraceWarning("warn");
            Trace.TraceInformation("info");
            Trace.TraceError("error");

            Trace.Unindent();
            Trace.WriteLine("WriteLineIf测试");
            Trace.Indent();
            Trace.WriteLineIf(true, new { 状态 = "处理中", 操作时间 = DateTime.Now }, "订单状态");
            Trace.WriteLineIf(true, new { 状态 = "成交", 操作人 = "hello girl" }, "订单状态");
            Trace.WriteLine(new { 状态 = "部分收款", 操作时间 = DateTime.Now }, "收款状态");
            Trace.WriteLine(new { 状态 = "已收全款", 操作时间 = DateTime.Now }, "收款状态");
            Trace.IndentLevel = 0;
            Trace.WriteLine("\r\n\r\nEnd\r\n\r\n");


            //Trace.Fail("message.Fail了", "detailMessage.Fail了，Fail了，全Fail了");
            //Trace.Assert(false, "好吧，弹出");
        }


        private static void ConditionalAttributeTest()
        {
            Console.WriteLine("Calling Method1");
            Method1(3);
            Console.WriteLine("Calling Method2");
            Method2();
        }

        [Conditional("CONDITION1")]
        private static void Method1(int x)
        {
            Console.WriteLine("CONDITION1 is defined");
        }

        [Conditional("CONDITION1"), Conditional("CONDITION2")]
        private static void Method2()
        {
            Console.WriteLine("CONDITION1 or CONDITION2 is defined");
        }
    }
}
