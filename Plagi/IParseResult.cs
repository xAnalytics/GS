using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParserLib {
    public interface IParseResult {

        string Link { get; set; }
        /// <summary>
        /// Contains only domain name and extension without http, https, www etc.
        /// </summary>
        string LinkStripped { get; }
        string Text { get; set; }
        string TextBold { get; set; }
        string Caption { get; set; }
        string CaptionBold { get; set; } 

    }
}
