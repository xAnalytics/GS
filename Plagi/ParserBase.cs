using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Diagnostics;

namespace ParserLib {
    public abstract class ParserBase {

        public abstract List<string> Parse(string _stringToParse);

        protected virtual HtmlDocument CreateHtmlDocument(string _stringToParse) {
           
            HtmlDocument result = new HtmlDocument();
            try {
                result.LoadHtml(_stringToParse);
                if (result.ParseErrors != null && result.ParseErrors.Count() > 0) {
                    Debug.WriteLine(string.Format("ParserBase.CreateHtmlDocument ParseErrors: {0}", result.ParseErrors));
                }
            } catch (Exception ex) {
                Debug.WriteLine(string.Format("ParserBase.CreateHtmlDocument Exception: {0}", ex));                
            }

            return result;
        }

    }
}
