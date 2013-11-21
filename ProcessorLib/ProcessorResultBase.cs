using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProcessorLib {
    public class ProcessorResultBase {

        public ProcessorResultBase(bool _isSuccess, Exception _exception) {
            IsSuccess = _isSuccess;
            Exception = _exception;
        }

        public bool IsSuccess { get; set; }
        public Exception Exception { get; set; }

    }
}
