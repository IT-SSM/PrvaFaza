using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using SQLModifications.Logger;

namespace SQLModifications.Broker
{
    public class BrokerEscalation
    {
        #region Fields
        private static BrokerEscalation _instanca;
        private SqlConnection konekcija;
        private SqlTransaction transakcija;
        //private SqlCommand komanda;
        private Logger.Logger log = new Logger.Logger("Events", "Event");

        private Object locker = new Object(); 
        #endregion

        #region BrokerEscalation
        public static BrokerEscalation Instanca
        {
            get
            {
                if (_instanca == null)
                {
                    _instanca = new BrokerEscalation();
                }
                return _instanca;
            }
        }

        private BrokerEscalation()
        {
            konekcija = new SqlConnection(@"Data Source=ca172sql;Initial Catalog=ctickets;Integrated Security=True");
        }

        public void OtvoriKonekciju()
        {
            konekcija.Open();
        }

        public void ZatvoriKonekciju()
        {
            konekcija.Close();
        }

        public void PocniTransakciju()
        {
            transakcija = konekcija.BeginTransaction();

        }

        public void PotvrdiTransakciju()
        {
            transakcija.Commit();
        }

        public void PonistiTransakciju()
        {
            transakcija.Rollback();
        }
        #endregion

        #region Methods

        public List<SQLModifications.DomenskeKlase.Escalation> vratiSveEskalacije()
        {

            OtvoriKonekciju();
            List<SQLModifications.DomenskeKlase.Escalation> lista = new List<SQLModifications.DomenskeKlase.Escalation>();
            string upit = "SELECT * FROM dbo.escalations";
            SqlCommand komanda = new SqlCommand(upit, konekcija);
            DataTable tabela = new DataTable();
            SqlDataReader citac = komanda.ExecuteReader();
            tabela.Load(citac);

            foreach (DataRow red in tabela.Rows)
            {
                SQLModifications.DomenskeKlase.Escalation es = new SQLModifications.DomenskeKlase.Escalation();
                es.IdJob = Convert.ToInt32(red[0]);
                es.TableName = red[1].ToString();
                es.EscalationType = Convert.ToInt32(red[2]);
                es.Condition = red[3].ToString();
                es.Action = red[4].ToString();
                lista.Add(es);
            }
            ZatvoriKonekciju();
            return lista;
        }

        public bool Escalation2(string tableName, string condition)
        {
            int rezultat = 0;
            bool provera = false;
            try
            {
                if (konekcija.State == ConnectionState.Closed)
                {
                    OtvoriKonekciju();
                }
                PocniTransakciju();
                string upit = null;

                upit = "SELECT * FROM " + tableName + " WHERE " + condition + "";//"SELECT COUNT(" + txtCondition.Text + ") FROM " + cmbAssociatedForms.SelectedItem.ToString() + "";
                                                                                 // + cmbAssociatedForms.SelectedItem.ToString() + 

                SqlCommand komanda = new SqlCommand(upit, konekcija, transakcija);
                rezultat = (int)komanda.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "" + ex.StackTrace);
            }
            finally
            {
                if (rezultat < 0)
                {
                    provera = true;
                    PonistiTransakciju();
                }
                else
                {
                    PotvrdiTransakciju();
                }
                ZatvoriKonekciju();
            }
            return provera;
        }

        public bool PushField2(string action)
        {
            int rezultat = 0;
            bool provera = false;
            try
            {

                OtvoriKonekciju();
                PocniTransakciju();
                string upit = null;
                try
                {
                    upit = action;//cmbAssociatedForms.SelectedItem.ToString()
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

                SqlCommand komanda = new SqlCommand(upit, konekcija, transakcija);

                rezultat = komanda.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
            finally
            {
                if (rezultat == 0)
                {
                    provera = true;
                    PonistiTransakciju();
                }
                else
                {
                    PotvrdiTransakciju();
                }
                ZatvoriKonekciju();
            }
            return provera;
        }

        public int InsertIntoEscalationsInterval(ComboBox tableName, TextBox txtEscalation, TextBox condition, TextBox action)
        {
            int rezultat = 0;
            try
            {
                OtvoriKonekciju();
                PocniTransakciju();
                string upit = "INSERT INTO dbo.escalations (TableName, EscalationType, Condition , Action, Timer)" +
                              "values('" + tableName.SelectedItem.ToString() + "', " + Convert.ToInt32(txtEscalation.Text) + ", '" + condition.Text + "','" + action.Text + "', null)";
                SqlCommand komanda = new SqlCommand(upit, konekcija, transakcija);
                rezultat = komanda.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (rezultat == 1)
                {
                    PotvrdiTransakciju();
                }
                else
                {
                    PonistiTransakciju();
                }
                ZatvoriKonekciju();
            }
            return rezultat;
        }

        public int InsertIntoEscalationsTimer(ComboBox tableName, TextBox txtMessage, TextBox condition, TextBox action)
        {
            int rezultat = 0;
            try
            {
                OtvoriKonekciju();
                PocniTransakciju();
                string upit = "INSERT INTO dbo.escalations (TableName, EscalationType, Condition , Action, Timer)" +
                              "values('" + tableName.SelectedItem.ToString() + "', null, '" + condition.Text + "','" + action.Text + "', '" + txtMessage.Text + "')";
                SqlCommand komanda = new SqlCommand(upit, konekcija, transakcija);
                rezultat = komanda.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (rezultat == 1)
                {
                    PotvrdiTransakciju();
                }
                else
                {
                    PonistiTransakciju();
                }
                ZatvoriKonekciju();
            }
            return rezultat;
        }

        public async void pomocnaMetoda(string tableName, string condition, string action)
        {
            int rezultat = 0;
            // bool provera = false;
            int timeOut = 2000;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            /*try
            {
                //OtvoriKonekciju();

                if (konekcija.State == ConnectionState.Closed)
                {
                    konekcija.Open();
                }
                PocniTransakciju();
                //konekcija.Open();

                SqlCommand command = new SqlCommand();
                command = konekcija.CreateCommand();
                // transakcija = konekcija.BeginTransaction();
                command.Connection = konekcija;
                command.Transaction = transakcija;
                //"SELECT COUNT(" + txtCondition.Text + ") FROM " + cmbAssociatedForms.SelectedItem.ToString() + "";
                // + cmbAssociatedForms.SelectedItem.ToString() + 

                command.CommandText = "SELECT COUNT(*) FROM " + tableName + " WHERE " + condition + "";

                rezultat = (int)command.ExecuteNonQuery(); //rezultat = (int)command.ExecuteScalar();


                if (rezultat != 0)
                {
                    command.CommandText = action;
                    //SqlCommand komanda2 = new SqlCommand(upit, konekcija, transakcija);
                    command.ExecuteNonQuery(); //rezultat = command.ExecuteNonQuery();
                    transakcija.Commit();
                    log.WriteLine("Both records are written to database.");
                }
            }

            catch (Exception ex)
            {
                log.WriteLine("Commit Exception Type: {0}", ex.GetType());
                log.WriteLine("  Message: {0}", ex.Message);
                try
                {
                    // PonistiTransakciju();
                    transakcija.Rollback();
                }
                catch (Exception ex2)
                {

                    log.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                    log.WriteLine("  Message: {0}", ex2.Message);
                }

            }
            finally
            {
                konekcija.Close();
            }
        }*/
            while (true) { 
            
                try
                {
                    lock (locker)
                    {
                        //OtvoriKonekciju();
                        if (konekcija.State == ConnectionState.Closed)
                        {
                            konekcija.Open();
                        }

                        //PocniTransakciju();
                        SqlCommand command = new SqlCommand();
                        command = konekcija.CreateCommand();
                        transakcija = konekcija.BeginTransaction();
                        command.Connection = konekcija;
                        command.Transaction = transakcija;
                        //"SELECT COUNT(" + txtCondition.Text + ") FROM " + cmbAssociatedForms.SelectedItem.ToString() + "";
                        // + cmbAssociatedForms.SelectedItem.ToString() +

                        command.CommandText = "SELECT * FROM " + tableName + " WHERE " + condition + "";
                        rezultat = (int)command.ExecuteScalar(); //rezultat = (int)command.ExecuteScalar();

                        if (rezultat != 0)
                        {
                            command.CommandText = action;
                            //SqlCommand komanda2 = new SqlCommand(upit, konekcija, transakcija);
                            command.ExecuteNonQuery(); //rezultat = command.ExecuteNonQuery();
                            transakcija.Commit();
                           //log.WriteLine("Both records are written to database.");
                            log.WriteLine("SUCCESS :" + action);
                        }
                    }
                    //konekcija.Close();
                    break;
                }
                catch (Exception ex)
                {
                    log.WriteLine("Commit Exception Type: {​​​​0}​​​​" + ex.GetType() + action);
                    log.WriteLine(" Message: {​​​​0}​​​​" + ex.Message + action);
                    try
                    {
                        // PonistiTransakciju();
                        transakcija.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        log.WriteLine("Rollback Exception Type: {​​​​0}​​​​" + ex2.GetType() + action);
                        log.WriteLine(" Message: {​​​​0}​​​​" + ex2.Message + action);

                        if (stopwatch.ElapsedMilliseconds > timeOut)
                        {
                            //Give up.
                            break;
                        }
                        konekcija.Close();
                        await Task.Delay(2);
                    }
                }
            }
            stopwatch.Stop();
        }
    }
    #endregion
}
