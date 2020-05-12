using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{

    public partial class ClientForm : Form
    {
        UdpClient client;

        IPEndPoint endPoint;
        public ClientForm()
        {

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            //transmitem mesaj catre server
            int serverPort = int.Parse(txtServer.Text);
            int clientPort = int.Parse(txtClient.Text);
            string hostName = txtHost.Text;

            string msg = clientPort + "." + hostName + "." + txtMsg.Text;
            byte[] buffer = Encoding.Unicode.GetBytes(msg);

            //transmitem 
           
            client.Send(buffer, buffer.Length, hostName, serverPort);

            //primim
            endPoint = new IPEndPoint(IPAddress.Any, 0);
            buffer = client.Receive(ref endPoint);

            msg = Encoding.Unicode.GetString(buffer);

            WriteLog(msg);
        }
        private void WriteLog(string msg)
        {
            MethodInvoker invoker = new MethodInvoker(delegate { txtLog.AppendText("Server Said: " + msg + Environment.NewLine); });
            this.BeginInvoke(invoker);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            int txtCl = int.Parse(txtClient.Text);
            client = new UdpClient(txtCl);
        }
    }
}
