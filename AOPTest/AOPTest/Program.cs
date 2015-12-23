using MyAOP;
using NewAOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AOPTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var cc = new MyClass();
            cc.Say("你好");
        }
          
    }


    [Log()]
    public class MyClass : ContextBoundObject
    {
        public MyClass()
        {

        }

        [Log()]
        public void Say(string str)
        {
            Thread.Sleep(2000);
            Console.WriteLine(str);
        }
    }

    [Test(typeof(TestFactory), "1号路人")]
    [Test(typeof(TestFactory), "2号猪脚")]
    [AopProxy(typeof(AopControlProxyFactory))] //将自己委托给AOP代理AopControlProxy
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
