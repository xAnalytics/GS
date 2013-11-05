using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace GlobalSLib {
    public class BaseSearch: ISearch {

        private string searchString = string.Empty;

        #region ISearch Members

        public ISearchResult GetSearchResults(string _searchString) {
            SearchString = _searchString;
            ISearchResult result = new SearchResult(searchEngine);
            result.SearchString = SearchString;
            uri = new Uri(string.Format(baseSearchString + "={0}", SearchString));

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(uri);
            webRequest.UserAgent = "IE7";
            //webRequest.Proxy = new WebProxy("xx.xx.xx.xx:xx"); // << my proxy address : port
            var response = webRequest.GetResponse();
            result.SearchResponseRaw = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return result;
        }

        public ISearchResult GetSearchResults(string _searchString, int _numPages) {
            ISearchResult result = null;

            if (_numPages > -1) {
                var tmpResult = GetSearchResults(_searchString);
                if (result == null) {
                    result = new SearchResult(searchEngine);
                    result.SearchString = tmpResult.SearchString;
                    result.SearchResponseRaw = tmpResult.SearchResponseRaw;
                }
                for (int i = 1; i < _numPages; i++) {
                    var tmpBaseSearchSuffix = string.Format(baseSearchStringSuffix, pageMultiplier * i);
                    tmpResult = GetSearchResults(_searchString + tmpBaseSearchSuffix);
                    result.SearchResponseRaw += tmpResult.SearchResponseRaw;
                }
            }

            return result;
        }        
        

        #endregion
       

        public Uri uri { get; set; }        
        public string SearchString {
            get { return searchString; }
            set {                
                searchString = value.Trim().Replace(" ", "+");
            }
        }

        protected string baseSearchString;
        protected string baseSearchStringSuffix;
        protected int pageMultiplier;
        protected EnumSearchEngines searchEngine;

        #region Async Processing - Will be implemented later
        
        private void StartWebRequest() {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(uri);
            webRequest.BeginGetResponse(new AsyncCallback(FinishWebRequest), webRequest);
        }
        private void FinishWebRequest(IAsyncResult result) {
            HttpWebResponse response = (result.AsyncState as HttpWebRequest).EndGetResponse(result) as HttpWebResponse;
        }

        #endregion

    }
}
