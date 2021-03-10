using Microsoft.Win32.TaskScheduler;
using SQLModifications.WindowsForms.Escalation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;


namespace SQLModifications.WindowsForms
{
    public partial class PocetnaForma : Form
    {
        public static string database = "";
        KontrolerKorisnickogInterfejsa kki;
        public PocetnaForma()
        {
            InitializeComponent();
            kki = new KontrolerKorisnickogInterfejsa();
            //List<SQLModifications.DomenskeKlase.Escalation> lista = kki.vratiSveEskalacije();
            //foreach (var item in lista)
            //{
            //    System.Timers.Timer timer = new System.Timers.Timer();
            //    timer.Interval = item.EscalationType * 60000;
            //    timer.Elapsed += (sender, e ) =>  timer_Elapsed(sender, e, item);
            //    timer.Start();
            //}
            }

        private void OnElapsedTime(object sender, ElapsedEventArgs e, SQLModifications.DomenskeKlase.Escalation item)
        {
            kki.pomocnaMetoda(item.TableName, item.Condition, item.Action);
        }

        private void comboBoxDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDatabase.SelectedItem.ToString() == "MSSQL")
            {
                database = "MSSQL";
                new Meni().ShowDialog();

            }
            else if (comboBoxDatabase.SelectedItem.ToString() == "Oracle")
            {
                database = "Oracle";
                new Meni().ShowDialog();

            }
        }

        private  void PocetnaForma_Load(object sender, EventArgs e)
        {
            //CreateEscalation ce = new CreateEscalation();
            //var startTimeSpan = TimeSpan.Zero;
            //var periodTimeSpan = TimeSpan.FromMinutes(Convert.ToInt32(1));

            //var timer2 = new System.Threading.Timer((ev) =>
            //{

            //    Console.WriteLine("Provera je izvrsena!");
            //},null, startTimeSpan, periodTimeSpan);

            
            List<SQLModifications.DomenskeKlase.Escalation> lista = kki.vratiSveEskalacije();
            foreach (var item in lista)
            {
                Thread thread = new Thread(() =>
                {
                    //CreateEscalation ce = new CreateEscalation();
                    //var startTimeSpan = TimeSpan.Zero;
                    //var periodTimeSpan = TimeSpan.FromMinutes(Convert.ToInt32(item.EscalationType));
                    ////za interval treba da se dodaju sati i sekunde -> razmisliti kako cemo to upisivati u bazu u odnosu definisan interval
                    //var timer = new System.Threading.Timer((ev) =>
                    //{
                    //    // ce.pomMetoda();

                    //    //if (kki.Escalation2(item.TableName, item.Condition) == false)
                    //    //{
                    //    //   if (kki.PushField2(item.Action) == false)
                    //    //    {
                    //    //       Console.WriteLine("Provera je izvrsena!");
                    //    //     }   
                    //    //}

                    //    kki.pomocnaMetoda(item.TableName, item.Condition, item.Action);
                    //    // Console.WriteLine("Uspesno je izmenjeno!");
                    //}, null, startTimeSpan, periodTimeSpan);
                    item.Timer = new System.Timers.Timer();
                    item.Timer.Elapsed += (sender1, e1) => OnElapsedTime(sender1, e1, item);
                    item.Timer.Interval = item.EscalationType * 60000;
                    item.Timer.Enabled = true;
                });
                thread.Start();
                thread.Join();
            }

        }

       
    }
}
