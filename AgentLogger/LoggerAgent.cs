using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Timers;

namespace AgentLogger
{
    /**
     * Esta clase maneja el registro de datos del usuario por medio de la interfaz.
     * Se encarga de configurar la interfaz en base a los datos del usuario y tambien de dar señales de inicio y termino al registro de datos.
     */
    public partial class LoggerAgent : Form
    {
        LoginAgent login;
        public bool logKeys;
        System.Timers.Timer timer = new System.Timers.Timer();

        public LoggerAgent()
        {
            this.login = Persistence.Login;

            InitializeComponent();
            SetupGUI();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LimeLogger.Stop();
            login.Visible = true;
            this.Dispose();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quit();
        }

        /**
         * Configura la interfaz grafica
         */
        private void SetupGUI()
        {
            try
            {
                SetupLabels();
                SetupScheduleTable();
                SetupMenuBar();
                CheckFlags();
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.ToString());
            }
        }

        private void CheckFlags()
        {
            //if (now > clockin && now < clockout  PER DAY FFS)
            //    togglelogger();

            //string dayofweek = DateTime.Now.DayOfWeek.ToString();
            //DateTime now = DateTime.Now;

            //DateTime clockin;
            //DateTime clockout;

            ////DateTime out = 

            ////Console.Out.WriteLine("TODAY IS " + dayofweek);

            ////if (dayofweek.Equals("Saturday"))
            ////{
            ////    if (login.Agent.Json.sabadoin == null)


            ////    string sabadoin = login.Agent.Json.sabadoin;
            ////    string sabadoout = login.Agent.Json.sabadoout;

            ////    Console.Out.WriteLine("CLOCKIN AT " + );
            ////    Console.Out.WriteLine("CLOCKOUT AT " + );
            ////clockin = new DateTime(now.Year, now.Month, now.Day, );
            ////}
        }

        /**
         * Configura los elementos de la barra de navegacion segun configuracion del sistema
         * 
         */
        private void SetupMenuBar()
        {
            menuAutoStop.Checked = Persistence.Autostart;
            menuAutoStart.Checked = Persistence.Autostart;
            menuAutoLogin.Checked = Persistence.Autologin;
        }

        private void SetupLabels()
        {
            lblName.Text = "Nombre: " + login.Agent.Name;
            lblInstitution.Text = "Institucion: " + login.Agent.Institution;

        }


        /**
         * Rellena la tabla con los datos obtenidos desde el servidor
         */
        private void SetupScheduleTable()
        {
            //setup schedule
            DataTable dt = new DataTable();
            dt.Columns.Add("Dia");
            dt.Columns.Add("Ingreso");
            dt.Columns.Add("Salida");

            //lunes
            DataRow row = dt.NewRow();
            row["Dia"] = "Lunes";
            row["Ingreso"] = (string)login.Agent.Json.lunesin;
            row["Salida"] = (string)login.Agent.Json.lunesout;
            dt.Rows.Add(row);

            //martes
            row = dt.NewRow();
            row["Dia"] = "Martes";
            row["Ingreso"] = (string)login.Agent.Json.martesin;
            row["Salida"] = (string)login.Agent.Json.martesout;
            dt.Rows.Add(row);

            //miercoles
            row = dt.NewRow();
            row["Dia"] = "Miercoles";
            row["Ingreso"] = (string)login.Agent.Json.miercolesin;
            row["Salida"] = (string)login.Agent.Json.miercolesout;
            dt.Rows.Add(row);

            //jueves
            row = dt.NewRow();
            row["Dia"] = "Jueves";
            row["Ingreso"] = (string)login.Agent.Json.juevesin;
            row["Salida"] = (string)login.Agent.Json.juevesout;
            dt.Rows.Add(row);

            //viernes
            row = dt.NewRow();
            row["Dia"] = "Viernes";
            row["Ingreso"] = (string)login.Agent.Json.viernesin;
            row["Salida"] = (string)login.Agent.Json.viernesout;
            dt.Rows.Add(row);

            //sabado
            row = dt.NewRow();
            row["Dia"] = "Sabado";
            row["Ingreso"] = (string)login.Agent.Json.sabadoin;
            row["Salida"] = (string)login.Agent.Json.sabadoout;
            dt.Rows.Add(row);

            //domingo
            row = dt.NewRow();
            row["Dia"] = "Domingo";
            row["Ingreso"] = (string)login.Agent.Json.domingoin;
            row["Salida"] = (string)login.Agent.Json.domingoout;
            dt.Rows.Add(row);

            tableClockHours.DataSource = dt;
        }

       /**
        * Envia la señal de inicio y termino del registro de datos. Tambien cambia dicho estado en la interfaz
        */
        private void ToggleLogger()
        {
            logKeys = !logKeys;
            
            if (logKeys)
            {
                LimeLogger.Start();
                btnClockToggle.Text = "Detener registro";
                lblEstado.Text = "Estado: REGISTRANDO";

                timer.Elapsed += new ElapsedEventHandler(OnTimedSend);
                timer.Interval = Persistence.Interval; //default is 5 minutes
                timer.Start();
            }
            else
            {
                LimeLogger.Stop();
                LogManager.SendLog(login.Agent);
                btnClockToggle.Text = "Iniciar registro";
                lblEstado.Text = "Estado: En espera";

                timer.Stop();
            }
        }

        /**
         * Evento de envio de datos
         */
        private void OnTimedSend(object source, ElapsedEventArgs e)
        {
            Console.Out.WriteLine("TIMER SENDING THINGS");
            LogManager.SendLog(login.Agent);
        }

        private void LoggerAgent_FormClosed(object sender, FormClosedEventArgs e)
        {
            Quit();
        }

        /**
         * Operaciones a realizar al momento de cerrar la aplicacion: enviar datos, guardar configuraciones, y salir. 
         */
        private void Quit()
        {
            LogManager.SendLog(login.Agent);
            Persistence.Save();
            Application.Exit();
        }

        private void btnClockToggle_Click(object sender, EventArgs e)
        {
            ToggleLogger();
        }

        private void menuAutoLogin_Click(object sender, EventArgs e)
        {
            Persistence.Autologin = menuAutoLogin.Checked;
        }

        private void menuAutoStop_Click(object sender, EventArgs e)
        {
            Persistence.Autostop = menuAutoStop.Checked;
        }

        private void menuAutoStart_Click(object sender, EventArgs e)
        {
            Persistence.Autostart = menuAutoStart.Checked;
        }
    }
}
