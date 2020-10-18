﻿using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BasicHTTPServer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const string newLine = "\r\n";
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 12345);
            tcpListener.Start();

            while (true)
            {
                var client = tcpListener.AcceptTcpClient();
                using (var stream = client.GetStream())
                {
                    int byteLength = 0;
                    byte[] buffer = new byte[1000000];
                    var length = stream.Read(buffer, byteLength, buffer.Length);

                    string requestString = Encoding.UTF8.GetString(buffer, 0, length);

                    Console.WriteLine(requestString);

                    string html = $"<h1>Hello from RusServer {DateTime.Now}</h1>" +
                                  $"<form><input name=username /><input name=text />" +
                                  $"<input type=submit /></form>";

                    string response = "HTTP/1.1 200 OK" + newLine +
                        "Server: RusServer2020" + newLine +
                        "Content-Type: text/html; charset=utf-8" + newLine +
                        "Content-Length: " + html.Length + newLine +
                        newLine + html + newLine;

                    byte[] responseBytes = Encoding.UTF8.GetBytes(response);

                    stream.Write(responseBytes);

                    Console.WriteLine(new string('=', 70));
                }
            }
        }

        public static async Task ReadData()
        {
            Console.OutputEncoding = Encoding.UTF8;
            string url = "https://softuni.bg/";
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(string.Join(Environment.NewLine, response.Headers.Select(x => x.Key + ": " + x.Value.First())));

            //var html = await httpClient.GetStringAsync(url);
            //Console.WriteLine(html);
        }
    }
}
