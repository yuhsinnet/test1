using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        HubConnection connection;
        int i;
        public Form1()
        {
            InitializeComponent();
            connection = new HubConnectionBuilder()
           .WithUrl("https://localhost:44311/ChatHub")
           .Build();

            #region snippet_ClosedRestart
            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };
            #endregion
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                connection.StartAsync();
                textBox3.AppendText("Connection started");
                //connectButton.IsEnabled = false;
                //sendButton.IsEnabled = true;
            }
            catch (Exception ex)
            {
                textBox3.AppendText(ex.Message);
            }


            System.Threading.Timer ttmm = new System.Threading.Timer(new TimerCallback(AutoSend));
            ttmm.Change(1000, 1000);


        }

        private void AutoSend(object state)
        {
            #region snippet_ErrorHandling
            try
            {
                #region snippet_InvokeAsync
                connection.InvokeAsync("Sendint",
                    "Auto Bot", ++i);
                #endregion
            }
            catch (Exception ex)
            {
                textBox3.AppendText(ex.Message);
            }
            #endregion
        }
    }
}
