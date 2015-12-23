using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAOP
{
public  class Log
    {
        public static void  Say(string str)
        {
            Console.WriteLine("Log:"+str);
        }
    }
}
