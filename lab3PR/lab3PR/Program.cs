using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab3PR
{
    class program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            //Serials("1");
            //Serials("2");
            //Serials("3");
            //Serials("4");
            //Serials("5");
            //Serials("6");

            Request();

            Console.ReadKey();
        }

        static void Serials(string sezon)
        {
            List<string> serials = new List<string>();
            string resp = GetResponse(sezon);
            var str = Regex.Split(resp, "\n");

            Regex regex = new Regex(@"h4 [^/]*");
            Match match;
            int i = 0;
            foreach (var item in str)
            {
                match = regex.Match(str[i]);
                i++;
                if (match.Success)
                    serials.Add(match.Value);
            }



            List<string> serial = new List<string>();

            string[] Item;
            for (int j = 0; j < serials.Count; j++)
            {
                Item = serials[j].Split('<', '>');
                serial.Add(Item[1]);

            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n\t\t\t\tSezon {sezon}:");
            Console.ForegroundColor = ConsoleColor.White;
            for (int j = 0; j < serial.Count; j++)
            {
                Console.WriteLine(serial[j]);
            }

        }


        public static string GetResponse(string sezon)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://vikingi-online.info/season-" + $"{sezon}" + ".php");
            request.Method = "GET";
            String prob;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                Stream data = response.GetResponseStream();
                StreamReader streamrd = new StreamReader(data);
                prob = streamrd.ReadToEnd();
                streamrd.Close();
                data.Close();
            }

            return prob;
        }

        static async void HTTP_GET()
        {
            var url = "http://vikingi-online.info/season-6.php";

            HttpClientHandler httphandler = new HttpClientHandler()
            {
                Proxy = new WebProxy("http://112.133.214.242:80"),
                UseProxy = true,
            };

            Console.WriteLine("GET: + " + url);

            HttpClient client = new HttpClient(httphandler);

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);

                HttpContent content = response.Content;

                Console.WriteLine("Response StatusCode: " + (int)response.StatusCode);


                string result = await content.ReadAsStringAsync();


                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        static WebProxy getWebProxy()
        {
            return new WebProxy("http://112.133.214.242:80");
        }

        static void HttpClientRequest(HttpMethod httpMethod, string met)
        {
            Console.WriteLine();
            WebProxy proxy = getWebProxy();
            var _handler = new HttpClientHandler { Proxy = proxy };
            _handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;

            HttpClient httpClient = new HttpClient(_handler);

            Uri BaseUri = new Uri("http://vikingi-online.info/season-6.php");

            var result = httpClient.SendAsync(new HttpRequestMessage(httpMethod, BaseUri));
            result.Wait();

            Console.WriteLine(met);
            Console.WriteLine(result.Result);
            Console.WriteLine(met);
            Console.WriteLine();
        }

        public static void Request()
        {
            HttpClientRequest(HttpMethod.Get, "Get");
            HttpClientRequest(HttpMethod.Post, "Post");
            HttpClientRequest(HttpMethod.Head, "Head");
            HttpClientRequest(HttpMethod.Options, "Options");

        }

    }
}
