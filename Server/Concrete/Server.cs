using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.Concrete
{

    public class Server
    {
        const int PORT_NO = 5000;
        const string SERVER_IP = "127.0.0.1";
        public void Listener()
        {
            try
            {
                while (true)
                {

                    IPAddress localAdd = IPAddress.Parse(SERVER_IP);
                    TcpListener listener = new TcpListener(localAdd, PORT_NO);
                    Console.WriteLine("Dinliyor...");
                    listener.Start();
                    TcpClient client = listener.AcceptTcpClient();
                    NetworkStream nwStream = client.GetStream();
                    byte[] buffer = new byte[client.ReceiveBufferSize];
                    int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);
                    string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    Console.WriteLine("Alınan veri : " + dataReceived);
                    client.Close();
                    listener.Stop();


                }



            }
            catch (Exception)
            {

                Console.WriteLine("Hata var");
            }

        }
    }
}

////---write back the text to the client---
//Console.WriteLine("Geri Gönderme : " + dataReceived);
//nwStream.Write(buffer, 0, bytesRead);