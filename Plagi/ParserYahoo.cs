using System.Collections.Generic;
using HtmlAgilityPack;

namespace ParserLib {

    public class ParserYahoo: ParserBase {

        public override List<string> Parse(string _stringToParse) {

            List<string> result = null;
            var doc = CreateHtmlDocument(_stringToParse);

            if (doc != null && doc.DocumentNode != null) {
                result = new List<string>();
                var selNodes = doc.DocumentNode.SelectNodes("//div[(@class='res')]");
                foreach (HtmlNode link in selNodes) {
                    HtmlAttribute att = link.FirstChild.FirstChild.FirstChild.Attributes["href"];
                    if (att != null) result.Add(att.Value);
                }
            }

            return result;  
        }

    }

}
