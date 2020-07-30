using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentLogger
{
    /**
     *Clase encargada de la transferencia de informacion de usuario.
     *Utiliza una propiedad dinamica que recibe un json desde la pagina web y la utiliza para obtener la informacion del usuario
     */

    class Agent
    {
        private int id;
        private string name = "";
        private string username = "";
        private string password = "";
        private string type = "";
        private string institution = "";
        private string session = "";
        private dynamic json = "";
        private Dictionary<string, string> schedule;


        public Agent()
        {
            //blank constructor
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Type { get => type; set => type = value; }
        public string Institution { get => institution; set => institution = value; }
        public Dictionary<string, string> Schedule { get => schedule; set => schedule = value; }
        public string Session { get => session; set => session = value; }
        public dynamic Json { get => json; set => json = value; }
    }
}
