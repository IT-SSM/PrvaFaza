using SQLModifications.WindowsForms;
using SQLModifications.WindowsForms.Escalation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLModifications
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Logger.Logger log = new Logger.Logger();
            log.WriteLine("SQLModifications Application STARTED");
           Application.EnableVisualStyles();
           Application.SetCompatibleTextRenderingDefault(false);
           Application.Run(new PocetnaForma());
            
        }
    }
}
