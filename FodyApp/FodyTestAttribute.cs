using FodyApp;
using MethodDecorator.Fody.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
[module: MethodInterceptorAttribute]
namespace FodyApp
{

    
    /// <summary>
    /// 方法拦截
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor | AttributeTargets.Assembly | AttributeTargets.Module)]
    public class MethodInterceptorAttributeAttribute : Attribute, IMethodDecorator
    {

        // instance, method and args can be captured here and stored in attribute instance fields
        // for future usage in OnEntry/OnExit/OnException
        public void Init(object instance, MethodBase method, object[] args)
        {
            //TestMessages.Record(string.Format("Init: {0} [{1}]", method.DeclaringType.FullName + "." + method.Name, args.Length));
            string strArgs = string.Empty;
            if (args != null)
            {
                strArgs = string.Join(",", args);
            }
            Console.WriteLine($"Init methodName:{method.Name} args:{strArgs} ");
        }

        public void OnEntry()
        {
            //TestMessages.Record("OnEntry");
            Console.WriteLine("OnEntry");
        }

        public void OnExit()
        {
            //TestMessages.Record("OnExit");
            Console.WriteLine("OnExit");
        }

        public void OnException(Exception exception)
        {
            //TestMessages.Record(string.Format("OnException: {0}: {1}", exception.GetType(), exception.Message));
        }
    }
}
