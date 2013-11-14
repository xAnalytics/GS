#define USE_PARSE
#define USE_ASYNC

using System;
using GlobalSLib;
using ParserLib;
using System.Diagnostics;

namespace GS {
    class Program {

        static DateTime beginTime;

        static void Main(string[] args) {


            //ISearch syahoo = new SearchYahoo();
            //var result = syahoo.GetSearchResults("anxiety", 2);

            ISearch sr = new SearchGoogle();


            beginTime = DateTime.Now;

#if USE_ASYNC


            sr.GetSearchResultsAsync("anxiety", 5, ProcessResult);

            
#else
            var result = sr.GetSearchResults("anxiety", 50);

#if USE_PARSE

            var endTime = DateTime.Now;
            var totTime = (endTime - beginTime).TotalMilliseconds;
            Console.WriteLine("total execution time ms: {0}", totTime);

            ParserBase pparser = ParserFactoryStatic.GetParser(result.SearchEngine.ToString());

            var parseResults = pparser.Parse(result.SearchResponseRaw);

            if (parseResults != null) {
                for (int i = 0; i < parseResults.Count; i++) {
                    //Console.WriteLine("links[i]: " + links[i]);
                    Debug.WriteLine(string.Format("parseResults[{0}]: {1}", i, parseResults[i]));
                }
            }
#else
            var links = pparser.ParseGetLinks(result.SearchResponseRaw);
            if (links != null)
            {
                for (int i = 0; i < links.Count; i++)
                {
                    //Console.WriteLine("links[i]: " + links[i]);
                    Debug.WriteLine(string.Format("links[{0}]: {1}", i, links[i]));
                }
            }   
#endif    


#endif

            Console.ReadLine();

        }


        static private void ProcessResult(ISearchResult _result) {

            var endTime = DateTime.Now;
            var totTime = (endTime - beginTime).TotalMilliseconds;
            Console.WriteLine("total execution time ms: {0}", totTime);


            ParserBase pparser = ParserFactoryStatic.GetParser(_result.SearchEngine.ToString());

            var parseResults = pparser.Parse(_result.SearchResponseRaw);

            if (parseResults != null) {
                for (int i = 0; i < parseResults.Count; i++) {
                    //Console.WriteLine("links[i]: " + links[i]);
                    Debug.WriteLine(string.Format("parseResults[{0}]: {1}", i, parseResults[i]));
                }
            }

        }

    }
}
