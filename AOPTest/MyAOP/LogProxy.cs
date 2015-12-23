using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace MyAOP
{
    public class LogProxy : RealProxy
    {
        private MarshalByRefObject obj;

        public LogProxy(MarshalByRefObject obj, Type type) : base(type)
        {
            this.obj = obj;
        }
        public override IMessage Invoke(IMessage msg)
        {
            IMessage result;

            if (msg is IConstructionCallMessage)
            {
                // 获取最底层的默认真实代理
                RealProxy default_proxy = RemotingServices.GetRealProxy(this.obj);
                default_proxy.InitializeServerObject((IConstructionCallMessage)msg);
                MarshalByRefObject tp = (MarshalByRefObject)this.GetTransparentProxy(); //自定义的透明代理 this

                result = EnterpriseServicesHelper.CreateConstructionReturnMessage((IConstructionCallMessage)msg, tp);
            }
            else
            {                
                var call = (IMethodCallMessage)msg;
                Type type = GetProxiedType();
                var me = type.GetMethod(call.MethodName);

                var startTime = DateTime.Now;
                Console.WriteLine("开始执行方法:" + startTime);
                result = RemotingServices.ExecuteMessage(this.obj, call);

                var endTime = DateTime.Now;
                Console.WriteLine("执行方法完毕:" + endTime);
                Console.WriteLine("执行用时:"+(endTime-startTime));
            }

            //var call = (IMethodCallMessage)msg;
            //Type type = GetProxiedType();  
            //var me = type.GetMethod(call.MethodName);
            //if (me != null)
            //{
            //    Console.WriteLine("开始执行方法:" + DateTime.Now);
            //    result = RemotingServices.ExecuteMessage(this.obj, call);
            //    Console.WriteLine("执行方法完毕:" + DateTime.Now);

            //}
            //else
            //{
            //    // 获取最底层的默认真实代理
            //    RealProxy default_proxy = RemotingServices.GetRealProxy(this.obj);
            //    default_proxy.InitializeServerObject((IConstructionCallMessage)msg);
            //    MarshalByRefObject tp = (MarshalByRefObject)this.GetTransparentProxy(); //自定义的透明代理 this
                
            //    result = EnterpriseServicesHelper.CreateConstructionReturnMessage((IConstructionCallMessage)msg, tp);
            //}


            // IMethodMessage result_msg = RemotingServices.ExecuteMessage((MarshalByRefObject)base.GetTransparentProxy(), call); ;

            //var attrs = call.MethodBase.GetCustomAttributes(true);
            //attrs = call.MethodBase.GetCustomAttributes(false);

            //foreach (var item in attrs)
            //{
            //    if (item is LogAttribute)
            //    {
            //        var logAttr = item as LogAttribute;

            //        result_msg = RemotingServices.ExecuteMessage((MarshalByRefObject)base.GetTransparentProxy(), call);

            //    }
            //}

            return result;
        }
    }
}

