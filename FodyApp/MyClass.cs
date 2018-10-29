using MethodTimer;
using System;
using System.Collections.Generic;
using System.Text;

namespace FodyApp
{
   
    public class MyClass:IRun
    {
        public void Excute()
        {
            this.MyMethod();
        }

        [Time]
        public void MyMethod()
        {
            //Some code u are curious how long it takes
            Console.WriteLine("Hello");
        }

       
    }
}
