using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SUS.HTTP
{
    public class HttpServer : IHttpServer
    {
        private const int BufferSize = 4096;
        private const string newLine = "\r\n";
        IDictionary<string, Func<HttpRequest, HttpResponse>> routeTable = new Dictionary<string, Func<HttpRequest, HttpResponse>>();

        public void AddRoute(string path, Func<HttpRequest, HttpResponse> action)
        {
            if (routeTable.ContainsKey(path))
            {
                routeTable[path] = action;
            }
            else
            {
                routeTable.Add(path, action);
            }
        }

        public async Task StartAsync(int port)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, port);
            tcpListener.Start();
            while (true)
            {
                TcpClient client = await tcpListener.AcceptTcpClientAsync();
                ProcessClientAsync(client);
            }
        }

        private async Task ProcessClientAsync(TcpClient client)
        {
            using (var stream = client.GetStream())
            {
                List<byte> data = new List<byte>();
                int position = 0;
                byte[] buffer = new byte[BufferSize];
                while (true)
                {
                    int count = await stream.ReadAsync(buffer, position, buffer.Length);
                    position += count;

                    if (count < buffer.Length)
                    {
                        var realBuffer = new byte[count];
                        Array.Copy(buffer, realBuffer, count);
                        data.AddRange(realBuffer);
                        break;
                    }
                    else
                    {
                        data.AddRange(buffer);
                    }

                    if (count == 0)
                    {
                        break;
                    }
                }

                var request = Encoding.UTF8.GetString(data.ToArray());

                Console.WriteLine(request);

                var responseHtml = "<h1>Welcome!</h1>";
                var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);

                var responseHttp = "HTTP/1.1 200 OK" + newLine +
                "Server: SUS Server 1.0" + newLine +
                "Content-Type: text/html" + newLine +
                "Content-Length: " + responseBodyBytes.Length + newLine +
                newLine;

                var responseHeaderBytes = Encoding.UTF8.GetBytes(responseHttp);

                await stream.WriteAsync(responseHeaderBytes, 0, responseHeaderBytes.Length);
                await stream.WriteAsync(responseBodyBytes, 0, responseBodyBytes.Length);
            }
            client.Close();
        }
    }
}
