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

namespace Asp {
    public partial class KWPosition : System.Web.UI.Page {

        private int num_pages;
        
        protected void Page_Load(object sender, EventArgs e) {
            //var tmp = AppSettingsStatic.GetSettingValue("NUM_PAGES");
            //int.TryParse(tmp, out num_pages); 

            num_pages = 10;
        }

        protected void btnGo_Click(object sender, EventArgs e) {

            ISearch sr = new SearchGoogle();                        

            var processor = new ProcessorKWPosition(txtWebsite.Text, ResulsProcessing);
            sr.GetSearchResultsAsync(txtKeyword.Text, num_pages, processor.ProcessResult);

        }

        public void ResulsProcessing(object args) {
            if (args == null) return;

            var result = (ProcessorResultKWPosition)args;
            int counter = 0;
            foreach (var item in result.Positions) {
                counter++;
                txtResult.Text += string.Format("Occurance {0} at Position: {1}", counter, item);
            }

            Debug.WriteLine("txtResult.Text: " + txtResult.Text);
        }

        protected void Button1_Click(object sender, EventArgs e) {
            txtResult.Text = "TEST!";
        }
    }
}