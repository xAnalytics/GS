using System.Collections.Generic;
using HtmlAgilityPack;

namespace ParserLib {

    public class ParserYahoo: ParserBase {

        public override List<string> ParseGetLinks(string _stringToParse) {

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


        public override List<IParseResult> Parse(string _stringToParse) {
            List<IParseResult> result = null;

            var doc = CreateHtmlDocument(_stringToParse);

            if (doc != null && doc.DocumentNode != null) {
                result = new List<IParseResult>();
                var selNodes = doc.DocumentNode.SelectNodes("//div[(@class='res')]");
                foreach (HtmlNode link in selNodes) {
                    IParseResult parRes = new ParseResult();
                    HtmlAttribute att = link.FirstChild.FirstChild.FirstChild.Attributes["href"];   // getting link of the result
                    var abstr = link.ChildNodes[4];  //getting text of the result
                    var textBoldNode = abstr != null ? abstr.SelectSingleNode("b[1]") : default(HtmlNode);
                    var captionBoldNode = link.FirstChild.FirstChild.FirstChild != null ? link.FirstChild.FirstChild.FirstChild.SelectSingleNode("b[1]") : default(HtmlNode);

                    parRes.Link = att != null ? att.Value : null;
                    parRes.Caption = link.FirstChild.FirstChild != null ? link.FirstChild.FirstChild.InnerText : null;  // getting caption                             
                    parRes.Text = abstr != null ? abstr.InnerText : null;
                    parRes.TextBold = textBoldNode != null ? textBoldNode.InnerText : null;  // getting text's bold part
                    parRes.CaptionBold = captionBoldNode != null ? captionBoldNode.InnerText : null; // getting caption text in bold

                    result.Add(parRes);
                }
            }

            return result;
        }
    }

}
