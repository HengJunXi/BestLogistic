using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BestLogisticAdmin
{
    public class LastFormClosingApplicationContext : ApplicationContext
    {
        public LastFormClosingApplicationContext(Form mainForm) : base(mainForm) { }
        protected override void OnMainFormClosed(object sender, EventArgs e)
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                var form = Application.OpenForms[i];
                if (form != MainForm)
                {
                    MainForm = form;
                    return;
                }
            }
            base.OnMainFormClosed(sender, e);
        }
    }
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LastFormClosingApplicationContext(new Login()));
            
        }
    }
}
