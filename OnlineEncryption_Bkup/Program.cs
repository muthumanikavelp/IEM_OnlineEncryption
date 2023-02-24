using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;


namespace OnlineEncryption
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            //#if(!DEBUG)
            //    ServiceBase[] ServicesToRun;
            //    ServicesToRun = new ServiceBase[] 
            //    { 
            //        new MyService() 
            //    };
            //    ServiceBase.Run(ServicesToRun);
            //#else
            //    Service1 myServ = new Service1();
            //    myServ.OnlineFileEncryption();
            //#endif

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new Service1() 
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
