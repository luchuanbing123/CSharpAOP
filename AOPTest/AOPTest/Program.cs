using NewAOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOPTest
{
    class Program
    {
        static void Main(string[] args)
        {

            var sd = new msJsonSertest();
            //try
            //{
            //Exameplec epc = new Exameplec("添加代理的方法");
            //epc.say_hello();
            //Console.WriteLine("");
            //Console.WriteLine("--------------------------这是分隔符--------------------------------");


            //Exameplec epcs = new Exameplec("未添加代理的方法");
            //epcs.sayByeBye();
            //Console.WriteLine("--------------------------这是分隔符--------------------------------");

            ////}
            ////catch
            ////{
            ////    Console.WriteLine("报错了");
            ////}
            //Console.ReadLine(); 
        }
    }

    [Test(typeof(TestFactory), "1号路人")]
    [Test(typeof(TestFactory), "2号猪脚")]
    [AopProxyAttribute(typeof(AopControlProxyFactory))] //将自己委托给AOP代理AopControlProxy，（最好不要添加该代码）
    public class Exameplec : ContextBoundObject//放到特定的上下文中，该上下文外部才会得到该对象的透明代理
    {
        private string name;
        public Exameplec(string a)
        {
            this.name = a;
        }
        [MethodAopSwitcherAttribute(2, "参数")]
        public void say_hello()
        {
            Console.WriteLine("hello");
        }
        public void sayByeBye()
        {
            Console.WriteLine(name);
        }
    }
}
