using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FodyApp.Normal
{
    class Program
    {
        static void Main(string[] args)
        {
            //一般方法拦截
            MyClass myClass = new MyClass();
            myClass.Excute();

            //异常拦截
            //myClass.CalcUserName(null);
            

            //仿PostSharp方法拦截
            MyPerformanceClass pfClass = new MyPerformanceClass();
            pfClass.Excute();

            Console.Read();
        }
    }
}
