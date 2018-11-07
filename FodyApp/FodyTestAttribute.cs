using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace FodyApp
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Module)]
    public class FodyTestAttribute : Attribute
    {
        protected object InitInstance;

        protected MethodBase InitMethod;

        protected Object[] Args;

        public void Init(object instance, MethodBase method, object[] args)
        {
            InitMethod = method;
            InitInstance = instance;
            Args = args;
        }

        public void OnEntry()
        {
            Console.WriteLine("Before");
        }
        public void OnExit()
        {
            Console.WriteLine("After");
        }

        public void OnException(Exception exception)
        {
        }

    }
}
