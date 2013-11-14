using System.Collections.Generic;
using HtmlAgilityPack;

namespace ParserLib {
    public class ParserBing: ParserBase {

        public override List<string> ParseGetLinks(string _stringToParse) {

            List<string> result = null;
            var doc = CreateHtmlDocument(_stringToParse);

            if (doc != null && doc.DocumentNode != null) {
                result = new List<string>();
                var selNodes = doc.DocumentNode.SelectNodes("//div[(@class='sb_tlst')]");
                foreach (HtmlNode link in selNodes) {                        
                    HtmlAttribute att = link.FirstChild.FirstChild.Attributes["href"];
                    if (att != null) result.Add(att.Value);
                }
            }
            
            return result;  

        }


        public override List<IParseResult> Parse(string _stringToParse) {
            throw new System.NotImplementedException();
        }
    }
}
