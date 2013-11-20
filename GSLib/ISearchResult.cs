using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlobalSLib {
    public interface ISearchResult {
        string SearchResponseRaw { get; set; }
        string SearchString { get; set; }
        EnumSearchEngines SearchEngine { get; set; }
        int RequestNum { get; set; }
    }
}
