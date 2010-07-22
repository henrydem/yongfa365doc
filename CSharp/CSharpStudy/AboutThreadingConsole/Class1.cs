using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AboutThreading
{
    class Class1
    {
        /// <summary>
        /// 获得线程池中活动的线程数
        /// </summary>
        /// <returns></returns>
        public static int GetDoingThreads()
        {
            int MaxWorkerThreads, miot, AvailableWorkerThreads, aiot;

            //获得最大的线程数量
            ThreadPool.GetMaxThreads(out MaxWorkerThreads, out miot);

            AvailableWorkerThreads = aiot = 0;

            //获得可用的线程数量
            ThreadPool.GetAvailableThreads(out AvailableWorkerThreads, out aiot);

            //返回线程池中活动的线程数
            return MaxWorkerThreads - AvailableWorkerThreads;
        }
    }
}
