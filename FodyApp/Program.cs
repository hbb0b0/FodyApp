using System;
namespace FodyApp
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
