using System;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using BookLibrary.Model;
using System.Collections.Generic;
using Newtonsoft.Json;

public class Server
{
    static List<Book> books = new List<Book>()
        {
            new Book("1234567891012", "In Search of Lost Time", "Marcel Proust",4215),
            new Book("1234567891013", "Ulysses", "James Joyce",730),
            new Book("1234567891014", "Don Quixote", "Miguel de Cervantes",863),
            new Book("1234567891015", "The Great Gatsby", "F. Scott Fitzgerald",218)
        };

    static void Main(string[] args)
    {
        try
        {
            // set the TcpListener on port 13000
            int port = 4646;
            TcpListener server = new TcpListener(IPAddress.Any, port);
            TcpClient client;
            // Start listening for client requests
            server.Start();

            int clientNumber = 0;

            //Enter the listening loop
            while (true)
            {
                Console.Write("Waiting for a connection... ");
                client = server.AcceptTcpClient();
                ThreadProc(client, ref clientNumber);
            }

        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: {0}", e);
        }

        Console.Read();
    }
    private static void ThreadProc(object obj, ref int clientNumber)
    {
        byte[] bytes = new byte[1024];
        string data;
        clientNumber = 1;
        var client = (TcpClient)obj;
        Console.WriteLine("Connected!");

        // Get a stream object for reading and writing
        NetworkStream stream = client.GetStream();

        int i;

        // Loop to receive all the data sent by the client.
        i = stream.Read(bytes, 0, bytes.Length);
        while (i != 0)
        {
            // Translate data bytes to a ASCII string.
            data = Encoding.ASCII.GetString(bytes, 0, i);
            Console.WriteLine(string.Format("Received: {0}", data));
            string message = "not valid command";
            string[] words = data.ToLower().Split(' ');
            if (words[0].Trim() == "getall")
            {
                message = JsonConvert.SerializeObject(books);
            }
            if (words[0].Trim() == "get")
            {
                message = JsonConvert.SerializeObject(books.Find(e => e.ISBN == words[1]));
            }
            if (words[0].Trim() == "save")
            {
                string myjson = data.Split("{")[1].Split("}")[0];
                myjson = "{" + myjson + "}";
                books.Add(JsonConvert.DeserializeObject<Book>(myjson));
                message = "";
            }

            client.Close();
            Console.WriteLine("Client Disconnected");

            byte[] msg = Encoding.ASCII.GetBytes(message);

            stream.Write(msg, 0, msg.Length);
            Console.WriteLine(string.Format("Sent: {0}", message));

            Thread.Sleep(1000);

            Console.WriteLine("Sent: {0}", message);
        }
        client.Close();
        clientNumber--;


    }

}
