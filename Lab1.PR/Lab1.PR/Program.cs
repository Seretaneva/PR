﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Lab1.PR
{
    class Program
    {
        private static object syncLock = new object();
        static void Main(string[] args)
        {


            IPHostEntry hostInfo = Dns.GetHostEntry("utm.md");//definim hostul

            Console.WriteLine(hostInfo.AddressList[0]);
            Connect("utm.md", 80);//conectare la host
            string path = @"D:\Univer\Programarea in retea\Lab1.PR\WebSiteData.txt";//indicam calea
            string[] images = GetImagesPath(path);//calea catre imagini


            Console.WriteLine("Download started...");

            Parallel.For(0, images.Length, new ParallelOptions { MaxDegreeOfParallelism = 4 }, i => DownloadImage("unite.md", 80, images[i]));//utilizam max 4 fire de executie

        }

        private static void DownloadImage(string host, int port, string imageUrl)//metoda de descarcare a imaginilor
        {
            Console.WriteLine("downloading: " + imageUrl);// afisam textul "downloading" si url-ul imaginii descarcate in consola

            IPAddress[] IPs = Dns.GetHostAddresses(host);   //primim adresa hostului

            Socket socket = new Socket(AddressFamily.InterNetwork,  //cream un obiect socket
                SocketType.Stream,
                ProtocolType.Tcp);

            socket.Connect(IPs, port);  //Stabilește o conexiune la host.Hostul este specificat de o serie de adrese IP și un port

            string resp = null;

            var GetReq = $"GET {imageUrl} HTTP/1.1\r\nHost: {host}\r\nConnection: " +
                           $"keep-alive\r\nAccept: text/html\r\n\r\n";//indicam cimpurle
            socket.Send(Encoding.UTF8.GetBytes(GetReq));// (Cand este suprasolicitat intr-o clasa derivata, codifica toate caracterele din sirul specificat intr-o secventa de octeti). transmitem byte-tii sub forma codificata

            var bytesStored = new byte[socket.ReceiveBufferSize];//primim byte-ti (Marimea bufferului de primire, octeti)
            int responseSizeInBytes = socket.Receive(bytesStored);
            for (int i = 0; i < responseSizeInBytes; i++)
            {
                resp += $"{Convert.ToChar(bytesStored[i]).ToString()}";//convertim o valoare specificata in unicode integer
            }

            var index = resp.IndexOf("\r\n\r\n");//raporteaza indicele bazat pe zero pentru prima aparitie a sirului specificat

            resp = resp.Trim(); //elimina toate caracterele din spațiul liber (alb) si cele mai vechi din obiectul curent (string)

            int begin = imageUrl.LastIndexOf("/") + 1; //Raporteaza pozitia indexului bazata pe zero a ultimei aparitii a unui caracter sau a unui sir Unicode specificat 
            string imageName = imageUrl.Substring(begin, imageUrl.Length - begin);//numele imaginii (incepand de la o pozitie specificata pana la sfarsitul sirului)
            using var writer = new BinaryWriter(File.Open(@"D:\Univer\Programarea in retea\Images\" + imageName, FileMode.OpenOrCreate));//ne deschide sau creaza fisierul
            for (int i = index + 4; i < resp.Length; i++)
            {
                writer.Write((byte)resp[i]);//avansează poziția fluxului cu un octet
            }

            socket.Close();
        }

        public static void Connect(string host, int port)
        {
            IPAddress[] IPs = Dns.GetHostAddresses(host);

            Socket s = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp);

            s.Connect(IPs, port);
            Console.WriteLine("Connected to " + host);

            string request = "GET / HTTP/1.1\r\nHost: " + host + "\r\nAccept: *\r\n\r\n";
            int response = s.Send(Encoding.UTF8.GetBytes(request));

            byte[] buffer = new byte[20000];//cream un buffer de byte-ti

            FileStream file;
            string path = @"D:\Univer\Programarea in retea\Lab1.PR\WebSiteData.txt";//citim sau editam fisierul dat

            if (!File.Exists(path))
            {
                file = File.Create(path);//creem fisier
                file.Close();
            }

            File.WriteAllText(path, string.Empty);//completam fisierul cu string (cream un fisier nou, scriem continutul în fisier, apoi inchide fisierul. Daca fisierul exista deja, acesta este suprascris.

            while (true)
            {

                var receive = s.Receive(buffer);//primirea array-urilor cu byte-ti

                if (receive == 0)
                {
                    return;
                }

                string responseString = Encoding.ASCII.GetString(buffer, 0, receive);//primim informatia codata

                Console.WriteLine(responseString);
                File.AppendAllText(path, responseString + Environment.NewLine);//adauga text in fisier (adauga sirul specificat fisierului, creand fisierul daca nu exista) 
            }

        }

        public static string[] GetImagesPath(string path)
        {

            var lines = File.ReadLines(path);//variabila in care e localizat fisierul(citeste liniile file-ului)

            string[] images = new string[0];

            Regex regexPNGImages = new Regex("images.*.png");//utilizam expresia regulata
            Regex regexJPGImages = new Regex("images.*.jpg");

            int i = 0;
            foreach (var line in lines) // parseaza pagina, si downloadeaza imaginile in toate dimensiunile si formatele 
            {
                if (regexPNGImages.IsMatch(line))
                {
                    if (line.Contains("wide") || line.Contains("lazy") || line.Contains("narrow") )
                    {
                        int begin1 = line.IndexOf("wide=\"") + "wide=\"".Length;
                        int begin2 = line.IndexOf("narrow=\"") + "narrow=\"".Length;
                        int begin3 = line.IndexOf("lazy=\"") + "lazy=\"".Length;
                        int end = line.IndexOf("png\"") + "png\"".Length;
                        string imagePath = line.Substring(begin1, end - begin1 - 1);
                        string imagePath2 = line.Substring(begin2, end - begin2 - 1);
                        string imagePath3 = line.Substring(begin3, end - begin3 - 1);
                        Array.Resize(ref images, images.Length + 1);
                        images[i] = imagePath;
                        i++;
                    }
                    
                    else
                    {
                        int begin = line.IndexOf("src=\"") + "src=\"".Length;
                        int end = line.IndexOf("png\"") + "png\"".Length;
                        string imagePath = line.Substring(begin, end - begin - 1);
                        Array.Resize(ref images, images.Length + 1);
                        images[i] = imagePath;
                        i++;
                    }

                    

                }
                else if (regexJPGImages.IsMatch(line))
                {
                    if (line.Contains("wide") || line.Contains("narrow") || line.Contains("lazy") || line.Contains("src"))
                    {
                        int begin = line.IndexOf("wide=\"") + "wide=\"".Length;
                        int begin2 = line.IndexOf("narrow=\"") + "narrow=\"".Length;
                        int begin3 = line.IndexOf("lazy=\"") + "lazy=\"".Length;
                        int begin4 = line.IndexOf("src=\"") + "src=\"".Length;
                        int end = line.IndexOf("jpg\"") + "jpg\"".Length;
                        string imagePath = line.Substring(begin, end - begin - 1);
                        string imagePath2 = line.Substring(begin2, end - begin2 - 1);
                        string imagePath3 = line.Substring(begin3, end - begin3 - 1);
                        string imagePath4 = line.Substring(begin4, end - begin4 - 1);
                        Array.Resize(ref images, images.Length + 1);
                        images[i] = imagePath;
                        i++;

                       
                    }
                   
                    else
                    {
                        int begin = line.IndexOf("url('") + "url('".Length;
                        int end = line.IndexOf("jpg\'") + "jpg\'".Length;
                        string imagePath = line.Substring(begin, end - begin - 1);
                        Array.Resize(ref images, images.Length + 1);
                        images[i] = imagePath;
                        i++;
                    }


                }

            }

            return images;
        }
    }
}