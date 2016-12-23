using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiOwin.App_Start
{
    public class IocContainer
    {
        private static volatile ContainerBuilder instance = null;

        private static object syncRoot = new object();

        public static ContainerBuilder Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new ContainerBuilder();
                    }
                }

                return instance;
            }
        }
        
    }
}