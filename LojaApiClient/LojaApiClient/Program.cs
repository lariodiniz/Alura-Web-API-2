
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LojaApiClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string conteudo;
            string url = "http://localhost:54605/api/carrinho/1";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = "GET";
            request.Accept = "application/xml";

            WebResponse response = request.GetResponse();

            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reaader = new StreamReader(responseStream, Encoding.UTF8);
                conteudo = reaader.ReadToEnd();
            }

            Console.Write(conteudo);
            Console.Read();
        }

        public void TestaGet()
        {
            string conteudo;
            string url = "http://localhost:54605/api/carrinho/1";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = "GET";

            WebResponse response = request.GetResponse();

            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reaader = new StreamReader(responseStream, Encoding.UTF8);
                conteudo = reaader.ReadToEnd();
            }

            Console.Write(conteudo);
            Console.Read();
        }
    }
    
}
