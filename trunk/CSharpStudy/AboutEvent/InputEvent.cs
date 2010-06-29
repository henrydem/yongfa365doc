using System;
using System.Collections.Generic;
using System.Text;

namespace AboutDelegateEvent
{

    /// <summary>
    /// 请以事件的概念实现: 控制台屏幕录入任意字符串,并回显 "你键入了:" + 你刚才键入的字符串,如果键入 "q",退出程序,运行结束!
    /// </summary>
    class 事件Demo
    {
        static void Main3(string[] args)
        {
            MyClass cls = new MyClass();

            //订阅事件
            cls.OnInput += ShowInput;

            while (true)
            {
                Console.WriteLine("请键入任意字符(串),\"q\" 退出!");
                string s = Console.ReadLine();
                if (s == "q")
                {
                    break;
                }
                else
                {
                    //条件满足时调用相关方法，从而触发事件
                    cls.Run(s);
                }
            }
        }

        //方法在当前类里
        static void ShowInput(string str)
        {
            Console.WriteLine("你键入了:{0}\r\n\r\n", str);
        }

    }



    /// <summary>
    /// 事件及事件执行代码都放在一个封装的类里
    /// </summary>
    class MyClass
    {
        delegate void InputHandler(string s);
        public event InputHandler OnInput;
        public void Run(string str)
        {
            if (OnInput != null)
            {
                //触发事件
                OnInput(str);
            }
        }
    }
}

