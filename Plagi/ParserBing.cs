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
            List<IParseResult> result = null;

            var doc = CreateHtmlDocument(_stringToParse);

            if (doc != null && doc.DocumentNode != null) {
                result = new List<IParseResult>();
                var selNodes = doc.DocumentNode.SelectNodes("//div[(@class='sb_tlst')]");
                foreach (HtmlNode link in selNodes) {
                    IParseResult parRes = new ParseResult();
                    HtmlAttribute att = link.FirstChild.FirstChild.Attributes["href"];   // getting link of the result

                    var pText = link.ParentNode.ChildNodes["p"];  //getting text of the result
                    var textBoldNode = pText != null ? pText.SelectSingleNode("strong") : default(HtmlNode);
                    var captionBoldNode = link.FirstChild.FirstChild.FirstChild != null ? link.FirstChild.FirstChild.FirstChild : default(HtmlNode);

                    parRes.Link = att != null ? att.Value : null;
                    parRes.Caption = link != null ? link.InnerText : null;  // getting caption                             
                    parRes.Text = pText != null ? pText.InnerText : null;
                    parRes.TextBold = textBoldNode != null ? textBoldNode.InnerText : null;  // getting text's bold part
                    parRes.CaptionBold = captionBoldNode != null ? captionBoldNode.InnerText : null; // getting caption text in bold

                    result.Add(parRes);
                }
            }

            return result;            
        }
    }
}
