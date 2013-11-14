using System.Collections.Generic;
using HtmlAgilityPack;

namespace ParserLib {
    public class ParserGoogle: ParserBase {

        public override List<string> ParseGetLinks(string _stringToParse) {

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


        public override List<IParseResult> Parse(string _stringToParse) {
            List<IParseResult> result = null;

            var doc = CreateHtmlDocument(_stringToParse);

            if (doc != null && doc.DocumentNode != null) {
                result = new List<IParseResult>();
                var selNodes = doc.DocumentNode.SelectNodes("//li[(@class='g')]");
                foreach (HtmlNode link in selNodes) {
                    IParseResult parRes = new ParseResult();
                    HtmlAttribute att = link.FirstChild.FirstChild.Attributes["href"];   // getting link of the result

                    var pText = link.SelectSingleNode("//span[@class='st']");  //getting text of the result
                    var textBoldNode = pText != null ? pText.SelectSingleNode("b[1]") : default(HtmlNode);
                    var captionBoldNode = link.FirstChild.FirstChild.FirstChild != null ? link.FirstChild.FirstChild.FirstChild : default(HtmlNode);

                    parRes.Link = att != null && !string.IsNullOrEmpty(att.Value) ? CleanURL(att.Value) : null;
                    parRes.Caption = link != null && link.FirstChild != null ? link.FirstChild.InnerText : null;  // getting caption                             
                    parRes.Text = pText != null ? pText.InnerText : null;
                    parRes.TextBold = textBoldNode != null ? textBoldNode.InnerText : null;  // getting text's bold part
                    parRes.CaptionBold = captionBoldNode != null ? captionBoldNode.InnerText : null; // getting caption text in bold

                    result.Add(parRes);
                }
            }

            return result;
        }

        private string CleanURL(string _urlString) {

            var arr = !string.IsNullOrEmpty(_urlString) ? _urlString.Split('&') : default(string[]);
            var result = arr != null && arr.Length > 0 ? arr[0].Remove(0, 7) : null;

            return result;
        }

    }
}
