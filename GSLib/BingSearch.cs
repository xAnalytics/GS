using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlobalSLib {
    public class BingSearch: BaseSearch {

        public BingSearch() {
            baseSearchString = "http://www.bing.com/search?q";
            baseSearchStringSuffix = "&first={0}";
            pageMultiplier = 15;
            searchEngine = EnumSearchEngines.BING;
        }

    }
}
