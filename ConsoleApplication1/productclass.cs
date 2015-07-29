using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class productclass
    {
      public virtual void print()
        {
            Console.WriteLine("print A");
        }
    }

    class prodA : productclass
    {
      public override  void print()
        {
            Console.WriteLine("print B");
        }
    }
}
