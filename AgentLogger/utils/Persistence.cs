using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace AgentLogger
{    
    /**
     * Esta clase representa las configuraciones del programa. Se utiliza para acceder y modificar las configuraciones y preferencias.
     */
    public static class Persistence
    {
        private static readonly string loggerPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Purplecomet";
        private static LoginAgent login;

        private static bool autologin = true;
        private static bool autostart = true;
        private static bool autostop = true;

        private static string username = "";
        private static string password = "";

        private static string host = "http://127.0.0.1";

        private static int interval = 300000;

        /**
         * Intenta obtener la configuracion del usuario en base a un archivo de configuracion json. 
         * Si el archivo no existe, lo creara con parametros por defecto.
         */
        public static void Load()
        {
            try
            {
                Directory.CreateDirectory(loggerPath);
                
                if(File.Exists(loggerPath + @"\persistence.conf"))
                {
                    string serialconfig = File.ReadAllText(loggerPath + @"\persistence.conf");
                    Dictionary<string, object> config = JsonConvert.DeserializeObject<Dictionary<string, object>>(serialconfig);

                    //assign values
                    Autologin = (bool) config["autologin"];
                    Autostart = (bool) config["autostart"];
                    Autostop = (bool) config["autostop"];
                    Username = (string) config["username"];
                    Password = (string) config["password"];
                    Host = (string)config["host"];
                    Interval = Convert.ToInt32(config["interval"]);
                }
                else
                {
                    Save();
                }
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("Error loading presistence");
                Console.Out.WriteLine(ex.ToString());
            }
        }

        /**
         * Guarda las configuraciones en un archivo 
         */
        public static void Save()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(loggerPath + @"\persistence.conf", false))
                {
                    Dictionary<string, object> config = new Dictionary<string, object>();
                    config.Add("autologin", Autologin);
                    config.Add("autostart", Autostart);
                    config.Add("autostop", Autostop);
                    config.Add("username", Login.Agent.Username);
                    config.Add("password", Login.Agent.Password);
                    config.Add("host", Host);
                    config.Add("interval", Interval);

                    if (!Autologin)
                    {
                        config["username"] = "";
                        config["password"] = "";
                    }

                    string serialconf = JsonConvert.SerializeObject(config);

                    sw.Write(serialconf);
                }
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("Error saving persistence");
                Console.Out.WriteLine(ex.ToString());
            }
        }

        public static bool Autologin { get => autologin; set => autologin = value; }
        public static bool Autostart { get => autostart; set => autostart = value; }
        public static bool Autostop { get => autostop; set => autostop = value; }
        public static string Username { get => username; set => username = value; }
        public static string Password { get => password; set => password = value; }
        public static LoginAgent Login { get => login; set => login = value; }
        public static int Interval { get => interval; set => interval = value; }
        public static string Host { get => host; set => host = value; }
    }
}
