using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParserLib {
    public interface IParser {

        List<string> ParseGetLinks(string _stringToParse);
        List<IParseResult> Parse(string _stringToParse);

    }
}
