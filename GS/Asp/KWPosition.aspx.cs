using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GlobalSLib;
using ProcessorLib;
using System.Configuration;
using System.Diagnostics;
using System.Threading;

namespace Asp {
    public partial class KWPosition : System.Web.UI.Page {

        //private int num_pages;
        private string resultStr = string.Empty;
        
        protected void Page_Load(object sender, EventArgs e) {
            //var tmp = AppSettingsStatic.GetSettingValue("NUM_PAGES");
            //int.TryParse(tmp, out num_pages); 

          //  num_pages = 2;
        }

        protected void btnGo_Click(object sender, EventArgs e) {

            ISearch sr = new SearchGoogle();                        

            var processor = new ProcessorKWPosition(txtWebsite.Text, ResulsProcessing);
            //sr.GetSearchResultsAsync(txtKeyword.Text, num_pages, processor.ProcessResult);

            var res = sr.GetSearchResults(txtKeyword.Text, 2);
            var processResult = processor.ProcessResult(res);

            int counter = 0;
            foreach (var item in processResult.Positions) {
                counter++;
                var tmp = string.Format("Occurance {0} at Position: {1}", counter, item);
                //resultStr += tmp;
                lstKW.Items.Add(tmp);
            }
                       
        }

        public void ResulsProcessing(object args) {
            
            if (args == null) return;

            var result = (ProcessorResultKWPosition)args;
            int counter = 0;
            
            foreach (var item in result.Positions) {
                counter++;
                resultStr += string.Format("Occurance {0} at Position: {1}", counter, item);
            }
                       
        }

    }
}