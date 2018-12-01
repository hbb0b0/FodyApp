using AOP.Fody;
using MethodDecorator.Fody.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
[module: MethodInterceptorAttribute]
namespace AOP.Fody
{

    
    /// <summary>
    /// AOP 方法拦截
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor | AttributeTargets.Assembly | AttributeTargets.Module)]
    public class MethodInterceptorAttributeAttribute : Attribute, IMethodDecorator
    {

       
        /// <summary>
        /// 方法初始化
        /// </summary>
        /// <param name="instance">实例</param>
        /// <param name="method">方法名称</param>
        /// <param name="args">调用参数</param>
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

        /// <summary>
        /// 方法进入
        /// </summary>
        public void OnEntry()
        {
            //TestMessages.Record("OnEntry");
            Console.WriteLine("OnEntry");
        }

        /// <summary>
        /// 方法退出
        /// </summary>
        public void OnExit()
        {
            //TestMessages.Record("OnExit");
            Console.WriteLine("OnExit");
        }

        /// <summary>
        /// 方法异常
        /// </summary>
        /// <param name="exception"></param>
        public void OnException(Exception exception)
        {
            //TestMessages.Record(string.Format("OnException: {0}: {1}", exception.GetType(), exception.Message));
        }
    }
}
