using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client;
namespace Server
{
    public partial class ServerForm : Form
    {
        UdpClient server;
        IPEndPoint endPoint;
        public ServerForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            server = new UdpClient(int.Parse(txtServer.Text));
            endPoint = new IPEndPoint(IPAddress.Any, 0);

            WriteLog("Server started ...");
            Thread thr = new Thread(new ThreadStart(ServerStart));
            thr.Start();
            btnStart.Enabled = false;
        }
        private void ServerStart()
        {
            while (true)
            {
                //primim
                byte[] buffer = server.Receive(ref endPoint);

                string[] msg = Encoding.Unicode.GetString(buffer).Split('.');
                WriteLog("Client  at Port: " + msg[0]);
                WriteLog("At host : " + msg[1]);
                WriteLog("Message : " + msg[2]);

                //transmitem
                buffer = Encoding.Unicode.GetBytes(DateTime.Now.ToString());

                server.Send(buffer, buffer.Length, msg[1], int.Parse(msg[0]));
            }
        }
        private void WriteLog(string msg)
        {
            MethodInvoker invoker = new MethodInvoker(delegate { txtLog.AppendText(msg + Environment.NewLine); });
            this.BeginInvoke(invoker);
        } 

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClientForm c = new ClientForm();
            c.Show();
            
        }
    }
}
