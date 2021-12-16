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
                    //---listen at the specified IP and port no.---
                    IPAddress localAdd = IPAddress.Parse(SERVER_IP);
                    TcpListener listener = new TcpListener(localAdd, PORT_NO);
                    Console.WriteLine("Dinliyor...");
                    listener.Start();
                    TcpClient client = listener.AcceptTcpClient();

                    //---get the incoming data through a network stream---
                    NetworkStream nwStream = client.GetStream();
                    byte[] buffer = new byte[client.ReceiveBufferSize];

                    //---read incoming stream---
                    int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);

                    //---convert the data received into a string---
                    string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    Console.WriteLine("Alınan veri : " + dataReceived);

                    ////---write back the text to the client---
                    //Console.WriteLine("Geri Gönderme : " + dataReceived);
                    //nwStream.Write(buffer, 0, bytesRead);
                    client.Close();
                    listener.Stop();


                }

                //---incoming client connected---

                Console.ReadLine();



            }
            catch (Exception)
            {

                Console.WriteLine("Hata var");
            }

        }
    }
}
