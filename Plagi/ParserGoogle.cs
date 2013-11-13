using System.Collections.Generic;
using HtmlAgilityPack;

namespace ParserLib {
    public class ParserGoogle: ParserBase {

        public override List<string> Parse(string _stringToParse) {

            List<string> result = null;
            var doc = CreateHtmlDocument(_stringToParse);

            if (doc.DocumentNode != null) {
                result = new List<string>();
                foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]")) {
                    HtmlAttribute att = link.Attributes["href"];
                    if (att.Value.Contains(@"/url?q=http://") && !att.Value.Contains("webcache")) {
                        var lines = att.Value.Split('&');
                        if (lines != null && lines.Length > 0) result.Add(lines[0]);
                    }
                }
            }
            
            return result;            
        }

    }
}
