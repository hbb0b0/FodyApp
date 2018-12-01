using AOP.FodyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FodyApp.Normal
{
    public class MyPerformanceClass
    {
        public void Excute()
        {

            FastMethod();
            SlowMethod();
        }

        [PostSharpMethodInterceptor(Enabled =true,MaxRunTime =3000)]
        private void FastMethod()
        {
            Console.WriteLine("FastMethod");
        }

        [PostSharpMethodInterceptor(Enabled = true, MaxRunTime = 3000)]
        private void SlowMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"run Step :{i.ToString()}");
                Thread.Sleep(500);
            }
        }
    }
}
