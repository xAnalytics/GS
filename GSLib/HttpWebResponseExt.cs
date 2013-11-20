using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace GlobalSLib {
    public class HttpWebResponseExt {

        public HttpWebResponseExt(HttpWebResponse _response, int _rqNum) {
            HttpWebResponse = _response;
            RequestNum = _rqNum;
        }

        public HttpWebResponse HttpWebResponse { get; set; }
        public int RequestNum { get; set; }

    }
}
