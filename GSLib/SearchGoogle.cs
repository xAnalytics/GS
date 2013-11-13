using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlobalSLib {
    public class SearchGoogle: BaseSearch {

        public SearchGoogle() {
            baseSearchString = "http://www.google.com/search?q";
            baseSearchStringSuffix = "&start={0}";
            pageMultiplier = 10;
            searchEngine = EnumSearchEngines.GOOGLE;
        }


    }
}
