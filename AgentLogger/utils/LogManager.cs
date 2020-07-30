using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Specialized;
using System.Net;
using System.IO;

namespace AgentLogger
{
    /**
     * Clase encargada del envio y gestion interna de los registros del usuario.
     * Desde aqui se limpian los buffers en base a las respuestas del servidor.
     */
    class LogManager
    {
        public static readonly HttpClient client = new HttpClient();

        /**
         * Envia el registro al servidor y en caso exitoso limpiara los buffer temporales.
         */
        async public static void SendLog(Agent agent)
        {
            try
            {
                LimeLogger.StoreBuffer();

                using (var wb = new WebClient())
                {
                    var data = new NameValueCollection();
                    data["username"] = agent.Username;
                    data["password"] = agent.Password;
                    data["log"] = LimeLogger.GetFileBufferStr();

                    var response = wb.UploadValues(Persistence.Host + "/AgentLogger.aspx", "POST", data);
                    string responseStr = Encoding.UTF8.GetString(response);

                    Console.WriteLine("response: " + responseStr);

                    if (responseStr == "success")
                        LimeLogger.ClearFileBuffer();
                }


                //var values = new Dictionary<string, string>
                //{
                //    { "username", agent.Username },
                //    { "password", agent.Password },
                //    { "log", LimeLogger.GetFileBufferStr() }
                //};

                //var content = new FormUrlEncodedContent(values);
                //HttpResponseMessage response = await client.PostAsync(Persistence.Host + "/AgentLogger.aspx", content);
                //string responseString = await response.Content.ReadAsStringAsync();

                //Console.WriteLine("response: " + responseString);





                //WebRequest request = WebRequest.Create(Persistence.Host + "/AgentLogger.aspx");
                //request.Method = "POST";
                //request.ContentType = "application/x-www-form-urlencoded";








                //using (var client = new WebClient())
                //{
                //    var values = new NameValueCollection();
                //    values["username"] = agent.Username;
                //    values["password"] = agent.Password;
                //    values["log"] = LimeLogger.GetFileBufferStr();

                //    var response = client.UploadValues(Persistence.Host + "/AgentLogger.aspx", values);

                //    var responseString = Encoding.Default.GetString(response);
                //    Console.WriteLine("response: " + responseString);
                //}


            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("Error sending logs");
                Console.Out.WriteLine(ex.ToString());
            }
        }
    }
}
