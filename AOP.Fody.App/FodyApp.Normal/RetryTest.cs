using AOP.FodyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FodyApp.Normal
{
    public class RetryTest
    {
        public void Excute()
        {

            this.Method();
        }

        [Retry(PerCallWaitTime =1, RetryMaxCount =3)]
        private void Method()
        {
            Console.WriteLine("RetryTest.Method");
            throw new Exception("Method");
        }
    }
}
