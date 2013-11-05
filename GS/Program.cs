using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GlobalSLib;
using ParserLib;
using System.Diagnostics;

namespace GS {
    class Program {
        static void Main(string[] args) {


            //ISearch sgoogle = new GoogleSearch();
            //var result = sgoogle.GetSearchResults("anxiety", 2);

            ISearch sbing = new BingSearch();
            var result = sbing.GetSearchResults("anxiety", 2);


            BaseParser pparser = ParserFactoryStatic.GetParser(result.SearchEngine.ToString());
            var links = pparser.Parse(result.SearchResponseRaw);

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
