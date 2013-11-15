using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GlobalSLib;

namespace ProcessorLib {

    public interface IProcessor {

        void ProcessResult(ISearchResult _result);

    }

}
