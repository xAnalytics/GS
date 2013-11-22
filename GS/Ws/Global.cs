﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.WebHost.Endpoints;
using Funq;

namespace Ws {
    public class Global : System.Web.HttpApplication {

        /// <summary>
        /// Create your ServiceStack web service application with a singleton AppHost.
        /// </summary>        
        public class HelloAppHost : AppHostBase {
            /// <summary>
            /// Initializes a new instance of your ServiceStack application, with the specified name and assembly containing the services.
            /// </summary>
            public HelloAppHost() : base("Hello Web Services", typeof(HelloService).Assembly) { }

            /// <summary>
            /// Configure the container with the necessary routes for your ServiceStack application.
            /// </summary>
            /// <param name="container">The built-in IoC used with ServiceStack.</param>
            public override void Configure(Container container) {
                //Register user-defined REST-ful urls. You can access the service at the url similar to the following.
                //http://localhost/ServiceStack.Hello/servicestack/hello or http://localhost/ServiceStack.Hello/servicestack/hello/John%20Doe
                //You can change /servicestack/ to a custom path in the web.config.
                Routes
                  .Add<Hello>("/hello")
                  .Add<Hello>("/hello/{Name}");
            }
        }

        protected void Application_Start(object sender, EventArgs e) {
            //Initialize your application
            (new HelloAppHost()).Init();
        }


    }
}