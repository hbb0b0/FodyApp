using System;
namespace AOP.Fody
{
    class Program
    {
        static void Main(string[] args)
        {
            IRun run = new MyClass();
            run.Excute();

            Console.ReadLine();
        }
    }
}
