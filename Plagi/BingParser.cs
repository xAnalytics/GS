using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Diagnostics;

namespace ParserLib {
    public class BingParser: BaseParser {

        public override List<string> Parse(string _stringToParse) {
            List<string> result = null;
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(_stringToParse);
            if (doc.ParseErrors != null && doc.ParseErrors.Count() > 0) {
                Debug.WriteLine("Parse Errors");
            } else {
                if (doc.DocumentNode != null) {
                    result = new List<string>();
                    foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]")) {
                        HtmlAttribute att = link.Attributes["href"];
                        //if (att.Value.Contains(@"/url?q=http://") && !att.Value.Contains("webcache")) {
                        //    var lines = att.Value.Split('&');
                        //    result.Add(lines[0]);
                        //}



                        result.Add(att.Value);
                    }
                }
            }
            return result;            
        }

    }
}
