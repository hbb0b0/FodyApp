using MethodTimer;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOP.Fody
{
   
    public class MyClass:IRun
    {
        public void Excute()
        {
            this.MyMethod();
            this.FodyMethod("hbb0b0");
            this.PostSharpMethod("duoduo");
        }

        /// <summary>
        /// 统计耗时
        /// </summary>
        [Time]
        public void MyMethod()
        {
            //Some code u are curious how long it takes
            Console.WriteLine("Hello");
        }

        /// <summary>
        /// 方法拦截
        /// </summary>
        [MethodInterceptorAttribute]
        public void FodyMethod(string userName)
        {

        }


        [AopLog(Enabled =true)]
        public void PostSharpMethod(string businessNo)
        {
                     
        }




    }
}
