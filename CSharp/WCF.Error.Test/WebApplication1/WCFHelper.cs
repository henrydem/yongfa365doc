using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace CtripSZ.Frameworks.Extends {
    /// <summary>
    /// 
    /// </summary>
    public static class WCFHelper {

        /// <summary>
        /// 调用完成后，自动释放 client， 如果调用出错，会自动终止 client
        /// </summary>
        /// <param name="client"></param>
        /// <param name="act"></param>
        /// <param name="errorAct">发生异常时，调用这个 Action, 如果该值为 null, 则抛出这个异常</param>
        public static void Using(this ICommunicationObject client, Action act, Action<Exception> errorAct = null) {
            try {
                act();
                client.Close();
            } catch (Exception ex) {
                if (errorAct != null)
                    errorAct(ex);
                else
                    throw;
            } finally {
                if (client.State != CommunicationState.Closed)
                    client.Abort();
            }
        }

        /// <summary>
        /// WCF proxys do not clean up properly if they throw an exception. This method ensures that the service proxy is handeled correctly.
        /// Do not call TService.Close() or TService.Abort() within the action lambda.
        /// </summary>
        /// <typeparam name="TService">The type of the service to use</typeparam>
        /// <param name="action">Lambda of the action to performwith the service</param>

        public static void Using<TService>(Action<TService> action)
               where TService : ICommunicationObject, IDisposable, new() {
            var service = new TService();
            bool success = false;
            try {
                action(service);
                if (service.State != CommunicationState.Faulted) {
                    service.Close();
                    success = true;
                }
            } finally {
                if (!success) {
                    service.Abort();
                }
            }
        }


        //WCFHelper.Using(
        //    client =>

        //        {
        //            client.ClientCredentials.UserName.UserName = ConfigurationManager.AppSettings["username"];
        //            client.ClientCredentials.UserName.Password = ConfigurationManager.AppSettings["password"];
        //            client.CreateMember(mem);
        //            client.DeleteMember(mem.ExternalRef);
        //        }
        //    );
    }
}
