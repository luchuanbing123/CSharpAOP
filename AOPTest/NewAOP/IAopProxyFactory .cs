using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAOP
{
    public interface IAopProxyFactory
    {
        AopProxyBase CreateAopProxyInstance(MarshalByRefObject obj, Type type);
    }

    public interface ITestFactory
    {
        TestFactory CreateTestInstance();
    }

    public class TestFactory : ITestFactory
    {

        public TestFactory CreateTestInstance()
        {
            return new TestFactory();
        }

        public void SayHi(string str)
        {
            Console.WriteLine("Hi," + str + DateTime.Now.ToString());
        }
    }
}
