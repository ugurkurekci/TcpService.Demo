using System;
using System.Net.Sockets;
using System.Text;

namespace Client.Concrete
{

    public class Client
    {
        const int PORT_NO = 5000;
        const string SERVER_IP = "127.0.0.1";
        string textToSend;

        public void ClientPush()
        {
            try
            {
                while (true)
                {

                    Console.Write("Girdi:  ");
                    textToSend = Console.ReadLine();

                    TcpClient client = new TcpClient(SERVER_IP, PORT_NO);
                    NetworkStream nwStream = client.GetStream();
                    byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(textToSend); 
                    Console.WriteLine("Gönderilen Veri : " + textToSend);
                    nwStream.Write(bytesToSend, 0, bytesToSend.Length);
                    client.Close();
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Hata var");
            }


        }
    }
}


//---read back the text---
//byte[] bytesToRead = new byte[client.ReceiveBufferSize];
//int bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
//Console.WriteLine("Alınan Veri : " + Encoding.ASCII.GetString(bytesToRead, 0, bytesRead));
//Console.ReadLine();