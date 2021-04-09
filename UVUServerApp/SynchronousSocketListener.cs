using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace UVUServerApp
{
    class SynchronousSocketListener
    {
        ServerData sd;
        TcpListener tl;
        const int PORT = 11000;
        const string SERVER_ADDRESS = "127.0.0.1";

        public SynchronousSocketListener()
        {
            sd = new ServerData();
            sd.LoadFiles();
        }
        public void StartListening()
        {
            IPAddress ip = IPAddress.Parse(SERVER_ADDRESS);
            tl = new TcpListener(ip, PORT);
            tl.Start();

            Respond();
        }
        /// <summary>
        /// sets up the stream on the listener side. Takes in the users request and validates the input. IF it passes it will call a ServerData method to return a corresponding reponse. If data was invalid, sends back error message to client. 
        /// </summary>
        private void Respond()
        {
            Socket socket;
            while (true)
            {
                try
                {
                    socket = tl.AcceptSocket();

                    NetworkStream ns = new NetworkStream(socket);
                    StreamWriter sw = new StreamWriter(ns);
                    StreamReader sr = new StreamReader(ns);
                    sw.AutoFlush = true;
                    string clientRequest = sr.ReadLine();

                    if (clientRequest.ToUpper() == "UVUFACT")
                    {
                        string fact = sd.GetUVUFact();
                        sw.WriteLine(fact);
                    }
                    else if (clientRequest.ToUpper() == "UVUMAJORS")
                    {
                        string major = sd.GetUVUMajor();
                        sw.WriteLine(major);
                    }
                    else
                    {
                        sw.WriteLine($"Invalid request: {clientRequest}");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
