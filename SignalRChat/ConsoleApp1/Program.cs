using Microsoft.AspNetCore.SignalR.Client;
using System;



namespace ConsoleApp1
{
    class Program
    {


        
        static void Main(string[] args)
        {

            HubConnection connection = new HubConnectionBuilder()
                 .WithUrl("https://localhost:44311/ChatHub")
                 .Build();


            #region snippet_ConnectionOn
            connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                Dispatcher.Invoke(() =>
                {
                    var newMessage = $"{user}: {message}";
                    messagesList.Items.Add(newMessage);
                });
            });
            #endregion



            Console.WriteLine("Hello World!");
        }
    }
}
