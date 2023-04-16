using System;
using System.IO;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using LabRab_3.Дмитриченко;

namespace LabRab_3
{
    static class Program
    {
        public static ISerializable response;
        public static HttpListener listener;
        public static string URL = @"http://127.0.0.1:8888/connection/";
        public static string responseText =
    @"<!DOCTYPE html>
    <html>
        <head>
            <meta charset='utf8'>
            <title>METANIT.COM</title>
        </head>
        <body>
            <h2>TEST</h2>
        </body>
    </html>";

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            RunServer();
        }

        static void RunServer()
        {
            listener = new HttpListener();
            listener.Prefixes.Add(URL);
            listener.Start();

            var task = Server();
            task.GetAwaiter().GetResult();

            listener.Close();
        }

        static async Task Server()
        {
            bool runServer = true;
            while (runServer)
            {
                HttpListenerContext ctx = await listener.GetContextAsync();

                HttpListenerRequest req = ctx.Request;
                HttpListenerResponse resp = ctx.Response;

                if (req.HttpMethod == "GET")
                {
                    response = new DataSource();
                    responseText = @"<!DOCTYPE html>
    <html>
        <head>
            <meta charset='utf8'>
            <title>METANIT.COM</title>
        </head>
        <body>
            <h2>"+ JsonSerializer.Serialize<List<int>>(response.yearTable) +
                   JsonSerializer.Serialize<List<float>>(response.data) +
                   JsonSerializer.Serialize<List<float>>(response.valueChanges) + @"</h2>
        </body>
    </html>";
                }
                // response info
                string disableSubmit = !runServer ? "disable" : "";
                byte[] data = Encoding.UTF8.GetBytes(String.Format(responseText, disableSubmit));
                resp.ContentType = "text/html";
                resp.ContentEncoding = Encoding.UTF8;
                resp.ContentLength64 = data.LongLength;
                
                await resp.OutputStream.WriteAsync(data, 0, data.Length);
                resp.Close();
            }
        }
    }
}
