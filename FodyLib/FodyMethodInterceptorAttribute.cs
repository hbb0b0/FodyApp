using MethodDecorator.Fody.Interfaces;
using System;
using System.Reflection;

namespace AOP.FodyLib
{
    /// <summary>
    /// AOP 方法拦截
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor | AttributeTargets.Assembly | AttributeTargets.Module)]
    public class FodyMethodInterceptorAttribute : Attribute, IMethodDecorator
    {
        private MethodBase method;

        private object[] args;
        /// <summary>
        /// 方法初始化
        /// </summary>
        /// <param name="instance">实例</param>
        /// <param name="method">方法名称</param>
        /// <param name="args">调用参数</param>
        public void Init(object instance, MethodBase method, object[] args)
        {
            this.method = method;
            this.args = args;
            //TestMessages.Record(string.Format("Init: {0} [{1}]", method.DeclaringType.FullName + "." + method.Name, args.Length));
           
            Console.WriteLine($"Init methodName:{method.Name} args count:{args.Length} ");
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
            try
            {
                Console.WriteLine($"MehthdName:{this.method.Name} exception message:{exception.Message}");
            }
            finally
            {
                ;
            }
            
        }
    }
}
