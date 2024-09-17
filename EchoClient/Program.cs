using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EchoClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpClient clientSocket = new TcpClient("127.0.0.1", 14000);
            Console.WriteLine("client is ready");

            Stream ns = clientSocket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true;

            Console.WriteLine("write you message here: ");
            string message = Console.ReadLine();
            sw.WriteLine(message);
            string serverAnswer = sr.ReadLine();

            Console.WriteLine("Server answer: " + serverAnswer);
            Console.ReadLine();

            ns.Close();
            clientSocket.Close();
        }
    }
}
