﻿
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
            string url = "http://www.mocky.io/v2/52aaf5deee7ba8c70329fb7d";

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