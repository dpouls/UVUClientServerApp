using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UVUServerApp
{
    class Program
    {/// <summary>
    /// starts the client part of the app by using the Process class. Then starts the listener. 
    /// </summary>
    /// <param name="args"></param>
        static void Main(string[] args)
        {
            Process process = new Process();
            process.StartInfo.FileName = @"C:\Users\dalli\source\repos\UVUClientServerApp\UVUClientApp\bin\Debug\UVUClientApp.exe";
            process.Start();
            SynchronousSocketListener ssl = new SynchronousSocketListener();
            ssl.StartListening();

        }
    }
}
