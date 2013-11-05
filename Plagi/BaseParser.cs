using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Diagnostics;

namespace ParserLib {
    public abstract class BaseParser {

        public abstract List<string> Parse(string _stringToParse);

    }
}
