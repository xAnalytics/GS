using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace GlobalSLib {

    public class HttpWebRequestExt {

        public HttpWebRequestExt(HttpWebRequest _rq, int _rqNum, int _totalReqNum, Action<ISearchResult> _OnResultReady) {
            HttpWebRequest = _rq;
            RequestNum = _rqNum;
            TotalRequestNum = _totalReqNum;
            OnResultReady = _OnResultReady;
        }

        public HttpWebRequest HttpWebRequest { get; set; }
        public int RequestNum { get; set; }
        public int TotalRequestNum { get; set; }
        public Action<ISearchResult> OnResultReady { get; set; }        

    }
}
