using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlobalSLib {
    public class SearchResult: ISearchResult {

        public string SearchResponseRaw { get; set; }
        public string SearchString { get; set; }

    }
}
