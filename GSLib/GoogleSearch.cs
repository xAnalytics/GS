﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlobalSLib {
    public class GoogleSearch: BaseSearch {

        public GoogleSearch() {
            baseSearchString = "http://www.google.com/search?q";
            baseSearchStringSuffix = "&start={0}";
            pageMultiplier = 10;
            searchEngine = EnumSearchEngines.GOOGLE;
        }


    }
}
