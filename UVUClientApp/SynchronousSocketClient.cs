using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace UVUClientApp
{
    public class SynchronousSocketClient
    {
        const int SERVER_PORT = 11000;
        const string IP_ADDRESS = "127.0.0.1";
        //is this constructor necessary? I dont believe so.
        public SynchronousSocketClient()
        {

        }
        /// <summary>
        /// creates the tcp client and sets up the stream to send the user's input that will be passed into the function from the textbox. Closes the stream after the request is sent and response is read.. 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string ContactServer(string request)
        {
            string responseString = "";
            try
            {
                TcpClient tcpClient = new TcpClient();
                tcpClient.Connect(IPAddress.Parse(IP_ADDRESS), SERVER_PORT);
                NetworkStream networkStream = tcpClient.GetStream();

                StreamReader sr = new StreamReader(networkStream);
                StreamWriter sw = new StreamWriter(networkStream);

                sw.AutoFlush = true;
                sw.WriteLine(request);
                responseString = sr.ReadLine();

                networkStream.Close();
                tcpClient.Close();
            }
            catch (Exception ex)
            {
                responseString = ex.Message;
            }
            return responseString;
        }
    }
}
