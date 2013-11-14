using System;
using GlobalSLib;
using ParserLib;
using System.Diagnostics;

namespace GS {
    class Program {
        static void Main(string[] args) {


            //ISearch syahoo = new SearchYahoo();
            //var result = syahoo.GetSearchResults("anxiety", 2);

            ISearch sr = new SearchBing();
            var result = sr.GetSearchResults("anxiety", 2);

            ParserBase pparser = ParserFactoryStatic.GetParser(result.SearchEngine.ToString());
            var links = pparser.ParseGetLinks(result.SearchResponseRaw);

            if (links != null) {
                for (int i = 0; i < links.Count; i++) {
                    //Console.WriteLine("links[i]: " + links[i]);
                    Debug.WriteLine(string.Format("links[{0}]: {1}", i, links[i]));
                }
            }            

            Console.ReadLine();

        }
    }
}
