using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = SingletonInNet4.Instance;
            var b = SingletonInNet4.Instance;
            Console.WriteLine(a == b);

        }
    }


    public sealed class Singleton
    {
        private static readonly Singleton instance = new Singleton();

        private Singleton() { }

        public static Singleton Instance
        {
            get
            {
                return instance;
            }
        }
    }



    public sealed class SingletonLazyInit
    {
        private SingletonLazyInit() { }
        public static SingletonLazyInit Instance { get { return Nested.instance; } }

        private class Nested
        {
            static Nested() { }
            internal static readonly SingletonLazyInit instance = new SingletonLazyInit();
        }
    }



    public sealed class SingletonDoubleLock
    {
        private static SingletonDoubleLock instance = null;
        private static readonly object objLock = new object();

        private SingletonDoubleLock() { }

        public static SingletonDoubleLock Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (objLock)
                    {
                        if (instance == null)
                        {
                            instance = new SingletonDoubleLock();
                        }
                    }
                }
                return instance;
            }
        }
    }




    public sealed class SingletonInNet4
    {
        private static readonly Lazy<SingletonInNet4> lazy =
            new Lazy<SingletonInNet4>(() => new SingletonInNet4());

        private SingletonInNet4() { }

        public static SingletonInNet4 Instance { get { return lazy.Value; } }
    }



    //use Field
    public sealed class Singleton001
    {
        private Singleton001() { }
        public static readonly Singleton001 Instance = new Singleton001();
    }






}
