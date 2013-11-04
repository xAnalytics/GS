using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GlobalSLib;
using PlagiLib;
using System.Diagnostics;

namespace GS {
    class Program {
        static void Main(string[] args) {


            ISearch sgoogle = new GoogleSearch();
            var result = sgoogle.GetSearchResults("inferta analytics");

            //ISearch sbing = new BingSearch();
            //var result = sbing.GetSearchResults("inferta analytics");
            //Console.WriteLine(result.SearchResponseRaw);

            PlagiParser pparser = new PlagiParser();
            var links = pparser.Parse(result.SearchResponseRaw);

            if (links != null) {
                for (int i = 0; i < links.Count; i++) {
                    Console.WriteLine("links[i]: " + links[i]);
                    Debug.WriteLine("links[i]: " + links[i]);
                }
            }            

            Console.ReadLine();

        }
    }
}
