using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlobalSLib {
    public class SearchYahoo: BaseSearch {

        public SearchYahoo() {

            //http://search.yahoo.com/search?p=anxiety&b=21

            baseSearchString = "http://search.yahoo.com/search?p";
            baseSearchStringSuffix = "&b={0}";
            pageMultiplier = 10;
            searchEngine = EnumSearchEngines.YAHOO;
        }

    }
}
