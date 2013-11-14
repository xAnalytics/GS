using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParserLib {
    public class ParseResult: IParseResult {
        public string Link {
            get;
            set;
        }

        public string Text {
            get;
            set;
        }

        public string Caption {
            get;
            set;
        }
    }
}
