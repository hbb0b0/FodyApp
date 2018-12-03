using MethodDecorator.Fody.Interfaces;
using System;
using System.Reflection;
using System.Threading;

namespace AOP.FodyLib
{
    /// <summary>
    /// AOP 方法拦截
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor | AttributeTargets.Assembly | AttributeTargets.Module)]
    public class RetryAttribute : Attribute, IPartialDecoratorEntry,IPartialDecoratorInit3
    {
        private MethodBase m_method;
        private object m_instance;
        private object[] m_args;


        /// <summary>
        /// 重试的最大次数
        /// </summary>
        public int RetryMaxCount
        {
            get;
            set;
        }

        /// <summary>
        /// 每次调用间隔时间
        /// </summary>
        public int PerCallWaitTime
        {
            get;
            set;
        }
        /// <summary>
        /// 方法初始化
        /// </summary>
        /// <param name="instance">实例</param>
        /// <param name="method">方法名称</param>
        /// <param name="args">调用参数</param>
        public void Init(object instance, MethodBase method, object[] args)
        {
            this.m_instance = instance;
            this.m_method = method;
            this.m_args = args;

            Console.WriteLine($"Init methodName:{method.Name} args count:{args.Length} ");
        }

        /// <summary>
        /// 方法进入
        /// </summary>
        public void OnEntry()
        {
            for (int i = 0; i < RetryMaxCount; i++)
            {
                try
                {
                    var result = this.m_method.Invoke(this.m_instance, m_args);
                    return;
                }
                catch (Exception ex)
                {
                    if (i < RetryMaxCount)
                    {
                        Thread.Sleep(PerCallWaitTime);
                    }
                    else
                    {
                        throw ex;
                    }
                }
            }

        }

      
    }
}
