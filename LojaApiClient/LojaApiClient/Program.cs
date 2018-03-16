
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
            string url = "http://localhost:54605/api/carrinho/200";
            
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Accept = "application/xml";
            request.ContentType = "application/xml";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Headers["Location"]);
            Console.Read();
        }
        public void DeletaProduto()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:63275/api/carrinho/1/produto/3467");
            request.Method = "DELETE";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Console.WriteLine(response.StatusCode);

            Console.Read();
        }

        public void trocaQuantidadeProduto()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:63275/api/carrinho/1/produto/6237/quantidade");
            request.Method = "PUT";

            string xml = "[código XML aqui ... <Quantidade>10</Quantidade>...]";
            byte[] xmlBytes = Encoding.UTF8.GetBytes(xml);
            request.GetRequestStream().Write(xmlBytes, 0, xmlBytes.Length);

            request.ContentType = "Application/xml";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Console.WriteLine(response.StatusCode);

            Console.Read();
        }

        

        public void testaPostJSON()
        {
            string conteudo;
            string url = "http://localhost:54605/api/carrinho/1";


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";

            string json = "{'Produtos':[{'Id':6237,'Preco':4000.0,'Nome':'Xbox','Quantidade':3}],'Endereço':'Rua Vergueiro 3185, 8 andar, Sao Paulo','Id':2}";
            byte[] jsonBytes = Encoding.UTF8.GetBytes(json);
            request.GetRequestStream().Write(jsonBytes, 0, jsonBytes.Length);

            request.ContentType = "application/json";

            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                conteudo = reader.ReadToEnd();
            }
            Console.Write(conteudo);
            Console.Read();
        }

        public void testaPostXML()
        {
            string conteudo;
            string url = "http://localhost:54605/api/carrinho/1";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";

            string xml = "<Carrinho xmlns:i='http://www.w3.org/2001/XMLSchema-instance' xmlns='http://schemas.datacontract.org/2004/07/Loja.Models'>" +
                "< Endereco > Rua Vergueiro 3185, 8 andar, Sao Paulo</ Endereco >< Id > 3 </ Id >< Produtos >< Produto > " +
                "< Id > 123 </ Id > < Nome > Produto criado com POST </ Nome > < Preco > 100 </ Preco > < Quantidade > 1 </ Quantidade >" +
                " </ Produto > </ Produtos ></ Carrinho > ";
            byte[] xmlBytes = Encoding.UTF8.GetBytes(xml);
            request.GetRequestStream().Write(xmlBytes, 0, xmlBytes.Length);

            request.ContentType = "application/xml";

            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                conteudo = reader.ReadToEnd();
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

        public void TestaGetJSON()
        {
            string conteudo;
            string url = "http://localhost:54605/api/carrinho/1";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = "GET";
            request.Accept = "application/json";

            WebResponse response = request.GetResponse();

            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reaader = new StreamReader(responseStream, Encoding.UTF8);
                conteudo = reaader.ReadToEnd();
            }

            Console.Write(conteudo);
            Console.Read();
        }

        public void TestaGetXML()
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
    }
    
}
