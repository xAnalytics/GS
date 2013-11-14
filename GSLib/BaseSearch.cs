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
            ISearchResult result = new SearchResult(searchEngine);
            result.SearchString = SearchString;

            HttpWebRequest webRequest = InitWebRequest(_searchString);

            //webRequest.Proxy = new WebProxy("xx.xx.xx.xx:xx"); // << my proxy address : port
            var response = webRequest.GetResponse();
            result.SearchResponseRaw = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return result;
        }

        private HttpWebRequest InitWebRequest(string _searchString) {
            SearchString = _searchString;
            Uri = new Uri(string.Format(baseSearchString + "={0}", SearchString));
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(Uri);
            webRequest.UserAgent = "IE7";
            return webRequest;
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
       

        public Uri Uri { get; set; }        
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
        protected List<ISearchResult> lSearchResultsCache;

        #region Async Processing 

        public void GetSearchResultsAsync(string _searchString, int _numPages, Action<ISearchResult> _OnResultReady) {
            if (string.IsNullOrEmpty(_searchString) || _numPages < 0 || _OnResultReady == null) return;  // <- check parameters
            //prepare common search result cache
            lSearchResultsCache = new List<ISearchResult>();

            for (int i = 0; i < _numPages; i++) {
                StartWebRequest(_searchString, i, _numPages, _OnResultReady);
            }
        }

        private void StartWebRequest(string _searchString, int _index, int _totalReqNum, Action<ISearchResult> _OnResultReady) {
            HttpWebRequest webRequest = InitWebRequest(_searchString);
            HttpWebRequestExt webRequestExt = new HttpWebRequestExt(webRequest, _index, _totalReqNum, _OnResultReady);
            webRequest.BeginGetResponse(new AsyncCallback(FinishWebRequest), webRequestExt);
        }

        private void FinishWebRequest(IAsyncResult result) {

            HttpWebRequestExt webRequestExt = (result.AsyncState as HttpWebRequestExt);
            HttpWebResponse response = webRequestExt.HttpWebRequest.EndGetResponse(result) as HttpWebResponse;
            
            ISearchResult searchResult = new SearchResult(searchEngine);
            searchResult.SearchResponseRaw = new StreamReader(response.GetResponseStream()).ReadToEnd();

            lock (lSearchResultsCache) {
                // if list contains more elements than the Req.Num than we Insert otherwise Add
                if (lSearchResultsCache.Count > webRequestExt.RequestNum) {
                    lSearchResultsCache.Insert(webRequestExt.RequestNum - 1, searchResult);
                } else {
                    lSearchResultsCache.Add(searchResult);
                }
                // here we synch and check if the total request number equals already returned. If YES we raise OnresultReady event
                if (lSearchResultsCache.Count == webRequestExt.TotalRequestNum && webRequestExt.OnResultReady != null) {
                    //compose total response
                    ISearchResult totalResult = new SearchResult(searchEngine) { SearchString = webRequestExt.HttpWebRequest.RequestUri.ToString() };

                    foreach (var item in lSearchResultsCache) {
                        totalResult.SearchResponseRaw += item.SearchResponseRaw;
                    }
                    webRequestExt.OnResultReady(totalResult);
                }
            }
        }

        #endregion

    }
}
