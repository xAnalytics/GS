using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.ServiceHost;

namespace Ws {
    public class HelloService : IService {

        public object Any(Hello request) {
            //Looks strange when the name is null so we replace with a generic name.
            var name = request.Name ?? "Suka";
            return new HelloResponse { Result = "Hello, " + name };
        }


    }
}