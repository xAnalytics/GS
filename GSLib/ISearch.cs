using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlobalSLib {
    public interface ISearch {
        Uri Uri { get; set; }
        string SearchString { get; set; }
        ISearchResult GetSearchResults(string _searchString);
        ISearchResult GetSearchResults(string _searchString, int _numPages);
        void GetSearchResultsAsync(string _searchString, int _numPages, Action<ISearchResult> _OnResultReady);
    }
}
