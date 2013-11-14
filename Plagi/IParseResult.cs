using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParserLib {
    public interface IParseResult {

        string Link { get; set; }
        string Text { get; set; }
        string Caption { get; set; }

    }
}
