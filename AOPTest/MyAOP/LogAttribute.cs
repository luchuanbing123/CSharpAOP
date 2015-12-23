using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;

namespace MyAOP
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class LogAttribute : ProxyAttribute
    {
        /// <summary>
        /// 获得目标对象的自定义透明代理
        /// </summary>
        /// <param name="serverType">被修饰的类</param>
        /// <returns></returns>
        public override MarshalByRefObject CreateInstance(Type serverType)
        {
            var obj = base.CreateInstance(serverType);
            
            LogProxy logProxy = new LogProxy(obj, serverType);
            return (MarshalByRefObject)logProxy.GetTransparentProxy();
        }
    }
}
