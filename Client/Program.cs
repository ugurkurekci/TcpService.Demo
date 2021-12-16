using System;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Concrete.Client client = new Concrete.Client();
            client.ClientPush();


        }

    }
}
