﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GlobalSLib;
using ParserLib;

namespace ProcessorLib {

    public abstract class ProcessorBase<T> : IProcessor<T>, IDisposable {

        protected IParser parser;
        protected List<IParseResult> parseResults;

        /// <summary>
        /// _onProcessingFinished is called in derived classes when processing is finished
        /// </summary>
        /// <param name="_onProcessingFinished"></param>
        public ProcessorBase(Action<object> _onProcessingFinished) {
            OnProcessingFinished = _onProcessingFinished;
        }

        public ProcessorBase() {

        }

        #region IProcessor Members

        public Action<object> OnProcessingFinished { get; set; }

        public virtual void ProcessResultAsync(ISearchResult _result) {
            InitParser(_result);
        }

        private void InitParser(ISearchResult _result) {
            parser = ParserFactoryStatic.GetParser(_result.SearchEngine.ToString());
            parseResults = parser.Parse(_result.SearchResponseRaw);
        }

        public virtual T ProcessResult(ISearchResult _result) {
            InitParser(_result);
            return default(T);
        }

        #endregion


        #region IDisposable Members

        ~ProcessorBase() {
            Dispose(false);
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing) {
            if (disposing) {
                //cleaning event handler
                if (OnProcessingFinished != null) {
                    OnProcessingFinished = null;
                }
            }
        }

        #endregion
    }
}
