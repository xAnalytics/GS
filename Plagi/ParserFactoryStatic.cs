using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GlobalSLib;
using System.Diagnostics;

namespace ParserLib {
    public static class ParserFactoryStatic {

        public static BaseParser GetParser(string _searchEngine) {
            BaseParser result = null;
            if (string.IsNullOrEmpty(_searchEngine)) return result;
            switch (_searchEngine.ToUpper()) {
                case "GOOGLE":
                    result = new GoogleParser();
                    break;
                case "BING":
                    result = new BingParser();
                    break;
                default:
                    Debug.WriteLine(string.Format("Unknown Search Engine: {0}", _searchEngine));
                    break;
            }

            return result;
        }

    }
}
