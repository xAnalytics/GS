using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProcessorLib {
    
    /// <summary>
    /// Used To Return Execution Result
    /// </summary>
    public class ProcessorResultKWPosition : ProcessorResultBase {

        public ProcessorResultKWPosition(bool _isSuccess, Exception _exception, List<int> _positions) 
            :base(_isSuccess, _exception) {
                Positions = _positions;
        }

        public List<int> Positions { get; set; } 

    }

}
