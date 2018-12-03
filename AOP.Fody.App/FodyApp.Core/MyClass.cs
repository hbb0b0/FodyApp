using AOP.FodyLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace FodyApp.Core
{
   
    /// <summary>
    /// 需要应用AOP的类
    /// </summary>
    public class MyClass
    {
        public void Excute()
        {

            this.Method("hbb0b0");
        }

        /// <summary>
        /// 一般方法拦截
        /// </summary>
        [FodyMethodInterceptor]
        private void Method(string userName)
        {
            Console.WriteLine("Method Running");
        }

        /// <summary>
        /// 一般方法拦截
        /// </summary>
        [FodyMethodInterceptor]
        public void CalcUserName(string userName)
        {
            Console.WriteLine("Method Running with Exception");

            if(userName.Length>6)
            {
                Console.WriteLine($"userName:{userName} length:{userName.Length}");
            }
            
        }


    }
}
