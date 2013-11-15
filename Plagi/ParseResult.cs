using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParserLib {
    public class ParseResult: IParseResult {        

        #region IParseResult Members

        public string Link { get; set; }               
        public string LinkStripped {
            get { 
                return GetStrippedLink(); 
            }
        }        
        public string Text { get; set; }
        public string TextBold { get; set; }
        public string Caption { get; set; }
        public string CaptionBold { get; set; } 

        #endregion


        public override string ToString() {
            return base.ToString() + string.Format(": Link: {0}, Caption: {1}, CaptionBold: {2}, Text: {3}, TextBold: {4}, LinkStripped: {5}",
                Link, Caption, CaptionBold, Text, TextBold, LinkStripped);
        }

        #region Private Methods

        private string GetStrippedLink() {
            var result = string.Empty;
            if (!string.IsNullOrEmpty(Link)) {
                Uri uri = new Uri(Link);
                if (uri != null) result = uri.GetLeftPart(UriPartial.Authority);
            }
            return result;
        }

        #endregion

    }
}
