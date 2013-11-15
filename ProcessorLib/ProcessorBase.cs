using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GlobalSLib;
using ParserLib;

namespace ProcessorLib {
    
    public abstract class ProcessorBase: IProcessor {

        protected IParser parser;
        protected List<IParseResult> parseResults;

        #region IProcessor Members

        public virtual void ProcessResult(ISearchResult _result) {

            parser = ParserFactoryStatic.GetParser(_result.SearchEngine.ToString());
            parseResults = parser.Parse(_result.SearchResponseRaw);

        }

        #endregion

    }
}
