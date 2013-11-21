#define USE_PARSE
#define USE_ASYNC

using System;
using GlobalSLib;
using ProcessorLib;

namespace GS {
    class Program {

        const int NUM_PAGES = 2;
        static DateTime beginTime;

        static void Main(string[] args) {

            //ISearch syahoo = new SearchYahoo();
            //var result = syahoo.GetSearchResults("anxiety", 2);

            ISearch sr = new SearchGoogle();
            beginTime = DateTime.Now;

#if USE_ASYNC

            //sr.GetSearchResultsAsync("anxiety", NUM_PAGES, ProcessResult);

            IProcessor processor = new ProcessorKWPosition("helpguide.org", ResulsProcessing);  
            //IProcessor processor = new ProcessorKWPosition("phobia-anxiety.org");


            //var processor = new ProcessorKWPosition("phobia-anxiety.org", ResulsProcessing);
            sr.GetSearchResultsAsync("anxiety", NUM_PAGES, processor.ProcessResult);
                    
#else
            var result = sr.GetSearchResults("anxiety", NUM_PAGES);

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


        private static void ResulsProcessing(object args) {
            if (args == null) return;

            var result = (ProcessorResultKWPosition)args;

            foreach (var item in result.Positions) {

                Console.WriteLine("site contains in position: {0}", item);

            }


        }

        //static private void ProcessResult(ISearchResult _result) {

        //    var endTime = DateTime.Now;
        //    var totTime = (endTime - beginTime).TotalMilliseconds;
        //    Console.WriteLine("total execution time ms: {0}", totTime);


        //    //ParserBase pparser = ParserFactoryStatic.GetParser(_result.SearchEngine.ToString());

        //    //var parseResults = pparser.Parse(_result.SearchResponseRaw);

        //    //if (parseResults != null) {
        //    //    for (int i = 0; i < parseResults.Count; i++) {
        //    //        //Console.WriteLine("links[i]: " + links[i]);
        //    //        Debug.WriteLine(string.Format("parseResults[{0}]: {1}", i, parseResults[i]));
        //    //    }
        //    //}

        //}

    }
}
