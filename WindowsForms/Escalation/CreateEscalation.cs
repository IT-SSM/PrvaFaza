using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Threading;


namespace SQLModifications.WindowsForms.Escalation
{
    public partial class CreateEscalation : Form
    {
        KontrolerKorisnickogInterfejsa kki;
        public CreateEscalation()
        {
            InitializeComponent();
            kki = new KontrolerKorisnickogInterfejsa();
        }

        private void CreateEscalation_Load(object sender, EventArgs e)
        {
            kki.vratiSveNaziveTabela(cmbAssociatedForms);
        }

        private void comboEscalationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboEscalationType.SelectedItem.ToString() == "Interval")
            {
                label3.Visible = true;
                txtDays.Visible = true;
                label4.Visible = true;
                txtHours.Visible = true;
                label5.Visible = true;
                txtMinutes.Visible = true;
                lblDaysOfWeek.Visible = false;
                cmbDaysOfWeek.Visible = false;
                mntCalendar.Visible = false;
                txtMessage.Visible = false;
                //dateTimePicker1.Visible = false;
            }
            else
            {
                // dateTimePicker1.Visible = true;
                lblDaysOfWeek.Visible = true;
                cmbDaysOfWeek.Visible = true;
                label3.Visible = false;
                txtDays.Visible = false;
                label4.Visible = true;
                txtHours.Visible = true;
                label5.Visible = true;
                txtMinutes.Visible = true;
                mntCalendar.Visible = true;
                txtMessage.Visible = true;
            }
        }

        private void btnCreateEscalation_Click(object sender, EventArgs e)
        {
            if (comboEscalationType.SelectedItem.ToString() == "Interval")
            {
                if (kki.InsertIntoEscalationsInterval(cmbAssociatedForms, txtMinutes, txtCondition, txtAction) == 1)
                {
                    MessageBox.Show("Eskalacija je uspesno kreirana!");
                }
            }
            else
            {
                if (kki.InsertIntoEscalationsTimer(cmbAssociatedForms, txtMessage, txtCondition, txtAction) == 1)
                {
                    MessageBox.Show("Eskalacija je uspesno kreirana!");
                }
            }
        }

        public void pomMetoda()
        {
            if (btnRunEscalation.InvokeRequired)
            {
                btnRunEscalation.Invoke(new Action(pomMetoda));
                return;
            }
            if (kki.Escalation2(cmbAssociatedForms.SelectedItem.ToString(), txtCondition.Text) == false)
            {
                if (kki.PushField2(txtAction.Text) == false)
                {
                    Console.WriteLine("Provera je izvrsena!");
                }
            }
        }

        private void btnRunEscalation_Click(object sender, EventArgs e)
        {
            if (comboEscalationType.SelectedItem.ToString() == "Interval")
            {
                Thread threadRun = new Thread(() =>
                {
                    var startTimeSpan = TimeSpan.Zero;
                    var periodTimeSpan = TimeSpan.FromMinutes(Convert.ToInt32(txtMinutes.Text));
                    var timer = new System.Threading.Timer((ev) =>
                    {
                        pomMetoda();
                    // Console.WriteLine("Uspesno je izmenjeno!");
                }, null, startTimeSpan, periodTimeSpan);
                });
                threadRun.Start();
                threadRun.Join();
            }
            else
            {
                if (!String.IsNullOrWhiteSpace(txtHours.Text) && !String.IsNullOrWhiteSpace(txtMinutes.Text)) //provera da li su TextBox-ovi prazni (Hours i Minutes)
                {
                    string dayDateTime = DateTime.Now.DayOfWeek.ToString(); //dan u nedelji iz DateTime-a
                    string dayComboBox = cmbDaysOfWeek.SelectedItem.ToString(); //izabran dan u ComboBox
                    int hours = Convert.ToInt32(txtHours.Text); //uneti sati u TextBox-u
                    int minutes = Convert.ToInt32(txtMinutes.Text); //uneti minuti u TextBox-u
                    int seconds = 0;

                    //var dailyTime = "12:26:00";

                    var dailyTime = "" + hours + ":" + minutes; //beleženje sati i minuta zajedno
                    var timeParts = dailyTime.Split(new char[1] { ':' }); //splitovanje sati i minuta uz znak :

                    var monthTime = mntCalendar.SelectionStart; //beleženje selektovanog datuma u kalendaru
                    var monthTimeParts = monthTime.Day; //vraća dan iz selektovanog datuma

                    string messageInfo = $"Every {dayComboBox} and every {monthTimeParts}th day in a month, action will be executed at: " + hours + ":" + minutes;

                    var dateNow = DateTime.Now; //sistemsko vreme

                    var date = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day,
                    int.Parse(timeParts[0]), int.Parse(timeParts[1]), seconds); //inicijalizacija funkcije DateTime

                    TimeSpan ts;

                    if (date > dateNow)
                        ts = date - dateNow;
                    else
                    {
                        date = date.AddDays(1);
                        ts = date - dateNow;
                    }

                    if (dayDateTime == dayComboBox || dateNow.Day == monthTimeParts) // za izabran dan ili redni broj dana u mesecu
                    {
                        Task.Delay(ts).ContinueWith((x) => Message()); //pokretanje Delay funkcije
                        if (monthTimeParts == 3)
                        {
                            messageInfo = $"Every {dayComboBox} and every {monthTimeParts}rd day in a Month, action will be executed!";
                        }

                        txtMessage.Text = messageInfo.ToString();
                    }
                    else
                    {
                        Console.WriteLine("Danas se ne izvršava metoda!");
                    }

                   // this.txtHours.Clear();
                   // this.txtMinutes.Clear();
                }
                else
                {
                    MessageBox.Show("Popunite polje za sate i minute", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void Message()
        {
            if (btnRunEscalation.InvokeRequired)
            {
                btnRunEscalation.Invoke(new Action(pomMetoda));
                return;
            }
            if (kki.Escalation2(cmbAssociatedForms.SelectedItem.ToString(), txtCondition.Text) == false)
            {
                if (kki.PushField2(txtAction.Text) == false)
                {
                    Console.WriteLine("Provera je izvrsena!");
                }
            }
        }
    }
}
