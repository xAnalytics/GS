using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlobalSLib {
    public class SearchResult: ISearchResult {

        public SearchResult(EnumSearchEngines _searchEngine) {
            SearchEngine = _searchEngine;
        }

        #region ISearchResult Members

        public string SearchResponseRaw { get; set; }
        public string SearchString { get; set; }
        public EnumSearchEngines SearchEngine { get; set; }
        public int RequestNum { get; set; }

        #endregion

    }
}
