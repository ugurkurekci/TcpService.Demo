using System;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {

            Concrete.Server server = new Concrete.Server();
            server.Listener();


        }
    }
}
