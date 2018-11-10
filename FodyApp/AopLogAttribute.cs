using MethodDecorator.Fody.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
[module: FodyApp.AopLogAttribute]
namespace FodyApp
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor | AttributeTargets.Assembly | AttributeTargets.Module)]
    public sealed class AopLogAttribute : Attribute, IMethodDecorator
    {
        private int m_filterRunTime = -1;

        public int FilterRunTime
        {
            get
            {
                return m_filterRunTime;
            }
            set
            {
                m_filterRunTime = value;
            }
        }
        public bool Enabled
        {
            get;
            set;
        }
        public string OrderID
        {
            get;
            set;
        }
        public StringBuilder LogContainer
        {
            get;
            set;
        }

        private MethodExecutionArgs eventArgs;

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

        public void OnEntry()
        {
            if (this.Enabled)
            {
                eventArgs.MethodExecutionTag = Stopwatch.StartNew();
            }
        }

        public void OnException(Exception exception)
        {
            Console.WriteLine($"MethodName:{eventArgs.Method.Name} Exception:{exception.Message} ");
        }


        public  void OnExit()
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
                    if (runTime > m_filterRunTime)
                    {
                        //callStackName = GetStackMethodName();
                        info = string.Format($"PfTest: methodName:{eventArgs.Method.Name} args:{argsCounter} CostTime:{runTime} ms");
                        //Logger.Ins.Info(info);
                        //Trace.TraceInformation(info);
                        Console.WriteLine(info);

                    }

                    sw = null;
                }
            }
        }

       
    }

    /// <summary>
    /// MethodExecutionArgs
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
            get;set;
        }

        public object MethodExecutionTag
        {
            get;set;
        }

        public MethodExecutionArgs(object instance, MethodBase methodBase, object[] args)
        {
            Instance = instance;
            Method = methodBase;
            Arguments = args;
        }
    }
}
