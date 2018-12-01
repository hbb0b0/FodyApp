using MethodDecorator.Fody.Interfaces;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace AOP.FodyLib
{
    /// <summary>
    /// 模仿PostSharp的方法拦截
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor | AttributeTargets.Assembly | AttributeTargets.Module)]
    public sealed class PostSharpMethodInterceptorAttribute : Attribute, IMethodDecorator
    {
        private int m_filterMaxRunTime = -1;

        /// <summary>
        /// 方法消耗的最大时间，单位毫秒
        /// 默认输出所有方法的执行时间，如果MaxRunTime=1000，enable=true 那么只输出
        /// 超过1000毫秒的方法
        /// </summary>
        public int MaxRunTime
        {
            get
            {
                return m_filterMaxRunTime;
            }
            set
            {
                m_filterMaxRunTime = value;
            }
        }
        /// <summary>
        /// 是否添加性能统计
        /// </summary>
        public bool Enabled
        {
            get;
            set;
        }
       
        /// <summary>
        /// 方法参数
        /// </summary>
        private MethodExecutionArgs eventArgs;

        /// <summary>
        /// 方法构造函数
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        public void Init(object instance, MethodBase method, object[] args)
        {

            eventArgs = new MethodExecutionArgs(instance, method, args);
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
            if (this.Enabled)
            {
                //方法进入，开始计时
                eventArgs.MethodExecutionTag = Stopwatch.StartNew();
            }
        }

        public void OnException(Exception exception)
        {
            Console.WriteLine($"MethodName:{eventArgs.Method.Name} Exception:{exception.Message} ");
        }

        /// <summary>
        /// 方法执行完毕
        /// </summary>
        public void OnExit()
        {
            int argsCounter = 0;
            string callStackName = string.Empty;
            if (eventArgs.Arguments != null)
            {
                argsCounter = eventArgs.Arguments.Length;
            }
            string info = "";
            if (this.Enabled)
            {
                var sw = eventArgs.MethodExecutionTag as Stopwatch;
                if (sw != null)
                {
                    sw.Stop();
                    long runTime = sw.ElapsedMilliseconds;
                    if (runTime > m_filterMaxRunTime)
                    {
                        info = string.Format($"PfTest: methodName:{eventArgs.Method.Name} args:{argsCounter} CostTime:{runTime} ms");
 
                        Console.WriteLine(info);

                    }

                    sw = null;
                }
            }
        }


    }

    /// <summary>
    /// 执行方法参数类
    /// </summary>
    public sealed class MethodExecutionArgs
    {
        private object Instance;
        public MethodBase Method
        {
            get;
            set;
        }

        public object[] Arguments
        {
            get; set;
        }

        public object MethodExecutionTag
        {
            get; set;
        }

        public MethodExecutionArgs(object instance, MethodBase methodBase, object[] args)
        {
            Instance = instance;
            Method = methodBase;
            Arguments = args;
        }
    }
}
