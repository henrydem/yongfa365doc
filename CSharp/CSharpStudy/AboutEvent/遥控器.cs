using System;
using System.Collections.Generic;
using System.Text;
namespace AboutDelegate
{
    delegate void 事件处理格式1();
    delegate void 事件处理格式2(int n);

    class 遥控器 //事件引发者
    {
        public event 事件处理格式1 事件之按下开键; //遥控器上的开关
        public event 事件处理格式1 事件之按下关键;
        public event 事件处理格式2 事件之按下数字键;//遥控器上的选台键
        public void 开机()
        {
            if (事件之按下开键 != null)
                事件之按下开键();
            //如果事件有响应者，发送事件给响应者
        }

        public void 关机()
        {
            if (事件之按下关键 != null)
                事件之按下关键();
        }
        public void 选台(int 频道)
        {
            if (事件之按下数字键 != null)
                事件之按下数字键(频道);
        }
    }


    class 电视机 //事件响应者
    {
        public void 开机()
        {
            Console.WriteLine("屏幕亮了");
        }
        public void 关机()
        {
            Console.WriteLine("屏幕熄了");
        }
        public void 转换频道(int n)
        {
            Console.WriteLine("频道{0}播放", n);
        }
    }
    class 程序运行环境   //用于触发事件
    {
        static void Main(string[] args)
        {
            遥控器 我的遥控器 = new 遥控器();
            电视机 我的电视机 = new 电视机();
            //关联"引发者"和"响应者"
            我的遥控器.事件之按下开键 += new 事件处理格式1(我的电视机.开机);
            我的遥控器.事件之按下关键 += new 事件处理格式1(我的电视机.关机);
            我的遥控器.事件之按下数字键 += new 事件处理格式2(我的电视机.转换频道);

            //开始触发事件了
            我的遥控器.开机();
            我的遥控器.选台(20);
            我的遥控器.选台(10);
            我的遥控器.选台(5);
            我的遥控器.关机();
            Console.ReadKey();
        }
    }
}