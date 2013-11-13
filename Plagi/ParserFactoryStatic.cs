using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GlobalSLib;
using System.Diagnostics;

namespace ParserLib {
    public static class ParserFactoryStatic {

        public static ParserBase GetParser(string _searchEngine) {
            ParserBase result = null;
            if (string.IsNullOrEmpty(_searchEngine)) return result;
            switch (_searchEngine.ToUpper()) {
                case "GOOGLE":
                    result = new ParserGoogle();
                    break;
                case "BING":
                    result = new ParserBing();
                    break;
                case "YAHOO":
                    result = new ParserYahoo();
                    break;
                default:
                    Debug.WriteLine(string.Format("ParserFactoryStatic.GetParser Unknown Search Engine: {0}", _searchEngine));
                    break;
            }

            return result;
        }

    }
}
