using AOP.FodyLib;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// 有关程序集的一般信息由以下
// 控制。更改这些特性值可修改
// 与程序集关联的信息。
//[assembly: AssemblyTitle("FodyApp.Core")]
[assembly: AssemblyDescription("")]
//[assembly: AssemblyConfiguration("")]
//[assembly: AssemblyCompany("")]
//[assembly: AssemblyProduct("FodyApp.Core")]
[assembly: AssemblyCopyright("Copyright ©  2018")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

//将 ComVisible 设置为 false 将使此程序集中的类型
//对 COM 组件不可见。  如果需要从 COM 访问此程序集中的类型，
//请将此类型的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("b20db76e-4849-4e24-8a21-8cf0cea7dc00")]

// 程序集的版本信息由下列四个值组成: 
//
//      主版本
//      次版本
//      生成号
//      修订号
//
//[assembly: AssemblyVersion("1.0.0.0")]
//[assembly: AssemblyFileVersion("1.0.0.0")]
//指定织入模块
//必须引入MethodDecorator.Fody.dll,才可以织入代码
[module: FodyMethodInterceptor]
[module: PostSharpMethodInterceptor]

