using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GlobalSLib;

namespace ProcessorLib {

    public interface IProcessor<T> {

        Action<object> OnProcessingFinished { get; set; }
        void ProcessResultAsync(ISearchResult _result);
        T ProcessResult(ISearchResult _result);

    }

}
