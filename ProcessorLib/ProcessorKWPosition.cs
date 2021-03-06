﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using GlobalSLib;

namespace ProcessorLib {

    public class ProcessorKWPosition : ProcessorBase<ProcessorResultKWPosition> {

        public ProcessorKWPosition(string _domainToFindPosition, Action<object> _onProcessingFinished)
            : base(_onProcessingFinished) {
            DomainToFindPosition = _domainToFindPosition;
        }

        public string DomainToFindPosition { get; set; }

        public override void ProcessResultAsync(ISearchResult _result) {
            //Debug.WriteLine("ProcessorKWPosition.ProcessResult => Total result came back: " + _result.SearchResponseRaw);
            //Debug.WriteLine("ProcessorKWPosition.ProcessResult => Total result came back");
            List<int> lPositions = null;
            ProcessorResultKWPosition result = null;

            try {
                base.ProcessResultAsync(_result);
                var counter = 0;
                if (parseResults != null) {
                    lPositions = new List<int>();
                    foreach (var item in parseResults) {
                        counter++;
                        if (item.LinkStripped.Contains(DomainToFindPosition)) {
                            //Debug.WriteLine(string.Format("Results contain domain: '{0}' at position: {1}", DomainToFindPosition, counter));
                            lPositions.Add(counter);
                        }
                    }
                }
                result = new ProcessorResultKWPosition(true, null, lPositions);   // <-- creating successfull result

            } catch (Exception ex) {

                result = new ProcessorResultKWPosition(false, ex, null);   // <-- creating failed result              

            } finally {

                if (OnProcessingFinished != null)
                    OnProcessingFinished(result);  // <-- returning results to the caller

            }
        }

        public override ProcessorResultKWPosition ProcessResult(ISearchResult _result) {

            List<int> lPositions = null;
            ProcessorResultKWPosition result = null;

            try {
                base.ProcessResultAsync(_result);
                var counter = 0;
                if (parseResults != null) {
                    lPositions = new List<int>();
                    foreach (var item in parseResults) {
                        counter++;
                        if (item.LinkStripped.Contains(DomainToFindPosition)) {
                            //Debug.WriteLine(string.Format("Results contain domain: '{0}' at position: {1}", DomainToFindPosition, counter));
                            lPositions.Add(counter);
                        }
                    }
                }
                result = new ProcessorResultKWPosition(true, null, lPositions);   // <-- creating successfull result            

            } catch (Exception ex) {
                Debug.WriteLine(string.Format("ProcessorResultKWPosition exception: {0}", ex.Message));                
            }

            return result;
        }

    }
}
