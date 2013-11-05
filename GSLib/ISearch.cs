using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlobalSLib {
    public interface ISearch {
        string SearchString { get; set; }
        ISearchResult GetSearchResults(string _searchString);
        ISearchResult GetSearchResults(string _searchString, int _numPages);
    }
}
