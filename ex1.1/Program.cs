using System;

namespace ex1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            FunctionsContainer funcList = new FunctionsContainer();
            funcList["Double"] = x => x * 2;
            Console.WriteLine(funcList["Double"].ToString());
        }
    }
}
