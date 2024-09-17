using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EchoSerever
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello socket press enter to start server");
            Console.ReadLine();
            int port = 14000;
            TcpListener listener = new TcpListener(IPAddress.Any, port);

            listener.Start();
            Console.WriteLine("server started waiting for connection");

            TcpClient connectionSocket = listener.AcceptTcpClient();

            Console.WriteLine("Server activated");

            //Get network stream
            NetworkStream ns = connectionSocket.GetStream();

            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true;

            string message = sr.ReadLine();
            string answer = "";
            while (message != null && message != "")
            {
                Console.WriteLine("Message: " + message);
                answer = message.ToUpper();
                sw.WriteLine(answer);
                message = sr.ReadLine();
            }
            ns.Close();
            Console.WriteLine("stream closed");
            connectionSocket.Close();
            listener.Stop();

        }
    }
}
