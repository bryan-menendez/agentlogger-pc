using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;
using System.Collections.Specialized;
using System.Threading;

namespace AgentLogger
{
    /**
     * Clase encargada del inicio de sesion en el sistema.
     */
    public partial class LoginAgent : Form
    {
        private Agent agent = new Agent();

        public LoginAgent()
        {
            InitializeComponent();
            OnStartup();
        }

        /**
         * Funciones de configuracion inicial del sistema, tales como hooks, cargado de configuraciones, y operaciones automaticas.
         */
        private void OnStartup()
        {
            Persistence.Login = this;
            Persistence.Load();

            if (!Persistence.Username.Equals("") && !(Persistence.Username == null) && Persistence.Autologin)
            {
                boxUsername.Text = Persistence.Username;
                boxPassword.Text = Persistence.Password;
                SendCredentials();
            }
        }

        /**
         * Proceso de envio de credenciales al servidor. 
         * Recibe una respuesta del servidor y lanza avisos MessageBox en base a esta.
         */
        private void SendCredentials()
        {
            btnLogin.Enabled = false;
            boxUsername.Enabled = false;
            boxPassword.Enabled = false;

            try
            {
                //sending data
                using (var wb = new WebClient())
                {
                    var data = new NameValueCollection();
                    data["username"] = boxUsername.Text;
                    data["password"] = boxPassword.Text;

                    var responseStream = wb.UploadValues(Persistence.Host + "/AgentLogin.aspx", "POST", data);
                    string responseStr = Encoding.UTF8.GetString(responseStream);

                    Console.WriteLine("response: " + responseStr);

                    try
                    {
                        dynamic json = JsonConvert.DeserializeObject(responseStr);
                        Agent.Json = json;
                    }
                    catch (Exception) { }

                    if (Agent.Json != null)
                    {
                        Agent.Id = Agent.Json.id;
                        Agent.Name = Agent.Json.nombre;
                        Agent.Institution = Agent.Json.institution;
                        Agent.Username = boxUsername.Text;
                        Agent.Password = boxPassword.Text;

                        new LoggerAgent().Visible = true;
                        Persistence.Login.Visible = false;
                    }
                    else
                    {
                        Persistence.Login.Visible = true;
                        MessageBox.Show("Credenciales invalidas");
                    }
                }

                //var values = new Dictionary<string, string>
                //{
                //    { "username", boxUsername.Text },
                //    { "password", boxPassword.Text }
                //};

                //var content = new FormUrlEncodedContent(values);

                //HttpClient client = LogManager.client;
                //HttpResponseMessage response = await client.PostAsync(Persistence.Host + "/AgentLogin?username="+ boxUsername.Text + "&password="+boxPassword.Text, content);

                //string responseString = await response.Content.ReadAsStringAsync();

                //this.Agent = new Agent();

                //Console.Out.WriteLine("QUERYING: " + Persistence.Host + "/AgentLogin.aspx");
                //Console.Out.WriteLine("responseraw: " + response.ToString());
            }
            catch(Exception ex)
            {
                Console.Out.WriteLine(ex.ToString());
                Persistence.Login.Visible = true;
                MessageBox.Show("Error al comprobar datos");
            }

            btnLogin.Enabled = true;
            boxUsername.Enabled = true;
            boxPassword.Enabled = true;
        }

        internal Agent Agent { get => agent; set => agent = value; }

        private void boxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendCredentials();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SendCredentials();
        }
    }
}
