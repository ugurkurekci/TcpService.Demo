using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client.Concrete
{
   
    public class Client
    {
        const int PORT_NO = 5000; //const proje kapsamında sabit hiç değişmicek.
        const string SERVER_IP = "127.0.0.1";
        string textToSend;
        public void ClientPush()
        {
            try
            {
                while (true)
                {

                    Console.Write("Not: ");
                    textToSend = Console.ReadLine(); //---Servere Gönderilen veri girişi---//


                    TcpClient client = new TcpClient(SERVER_IP, PORT_NO);
                    NetworkStream nwStream = client.GetStream();
                    byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(textToSend);
                    //---send the text---
                    Console.WriteLine("Gönderilen Veri : " + textToSend);
                    nwStream.Write(bytesToSend, 0, bytesToSend.Length);
                    //---read back the text---
                    //byte[] bytesToRead = new byte[client.ReceiveBufferSize];
                    //int bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
                    //Console.WriteLine("Alınan Veri : " + Encoding.ASCII.GetString(bytesToRead, 0, bytesRead));
                    //Console.ReadLine();
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
