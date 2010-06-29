using System;
using System.Collections.Generic;
using System.Text;

namespace AboutDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculatorStatic.Test();

            Calculator calc = new Calculator();
            calc.Test();

            AnonymousMethod m = new AnonymousMethod();
            m.Run();
        }
    }
}
