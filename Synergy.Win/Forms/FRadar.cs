using System;
using System.Windows.Forms;
using Gravity.Root.Common;
using Gravity.Root.Repositories;
using SMSClient;
using Synergy.Domain.Model;
using System.Linq;

namespace Synergy.Win.Forms
{
    delegate void displayEvent(string logEntry);
    delegate void clickEvent(object sender, EventArgs ea);

    public partial class FRadar : Form
    {
        ozSMSClient mySMSClient;

        public FRadar()
        {
            InitializeComponent();

            bConnect.Enabled = true;
            bDisconnect.Enabled = false;
            tbMessage.Enabled = false;
            tbTo.Enabled = false;
            bSend.Enabled = false;

            //Create SMS client
            mySMSClient = new ozSMSClient();

            //Wire up SMS client events
            mySMSClient.OnClientConnected += new SimpleEventHandler(mySMSClient_OnClientConnected);
            mySMSClient.OnClientDisconnected += new SimpleEventHandler(mySMSClient_OnClientDisconnected);
            mySMSClient.OnClientConnectionError += new ErrorEventHandler(mySMSClient_OnClientConnectionError);
            mySMSClient.OnMessageAcceptedForDelivery += new DeliveryEventHandler(mySMSClient_OnMessageAcceptedForDelivery);
            mySMSClient.OnMessageDeliveredToNetwork += new DeliveryEventHandler(mySMSClient_OnMessageDeliveredToNetwork);
            mySMSClient.OnMessageDeliveredToHandset += new DeliveryEventHandler(mySMSClient_OnMessageDeliveredToHandset);
            mySMSClient.OnMessageDeliveryError += new DeliveryErrorEventHandler(mySMSClient_OnMessageDeliveryError);
            mySMSClient.OnMessageReceived += new DeliveryEventHandler(mySMSClient_OnMessageReceived);
        }

        void addToEventListSynced(string logentry)
        {
            tbEvents.Text += logentry;
        }

        void addToEventList(string logentry)
        {
            //Events are invoked from a different thread, so they must be synchronized to 
            //the GUI thread.
            BeginInvoke(new displayEvent(addToEventListSynced), new object[] { logentry });
        }

        void mySMSClient_OnMessageReceived(object sender, DeliveryEventArgs e)
        {
            addToEventList(DateTime.Now.ToString() + " " + "Message received. Sender address: " + e.Senderaddress + " Message text: " + e.Messagedata + "\r\n");
            processMessageReceived(e);
        }

        private void processMessageReceived(DeliveryEventArgs e)
        {
            var task = Task.New();
            task.Entity.Name = e.Messagedata;
            task.Entity.CreatedById = getCreatedById(e.Senderaddress);
            task.Save();
        }

        string getCreatedById(string number)
        {
            var users = new Users();
            string name;

            switch (number)
            {
                case "+919581919135":
                    name = "Srikanth";
                    break;
                case "+919700678999":
                    name = "Sripathi";
                    break;
                default:
                    name = "Ashok";
                    break;
            }

            var user = users.GetAllUserEntities()
                            .Where(u => u.Name == name)
                            .FirstOrDefault();
            return user.Id;
        }

        void mySMSClient_OnMessageDeliveryError(object sender, DeliveryErrorEventArgs e)
        {
            addToEventList(DateTime.Now.ToString() + " " + "Message could not be delivered. ID: " + e.Messageid + " Error message: " + e.ErrorMessage + "\r\n");
        }

        void mySMSClient_OnMessageDeliveredToHandset(object sender, DeliveryEventArgs e)
        {
            addToEventList(DateTime.Now.ToString() + " " + "Message delivered to handset. ID: " + e.Messageid + "\r\n");
        }

        void mySMSClient_OnMessageDeliveredToNetwork(object sender, DeliveryEventArgs e)
        {
            addToEventList(DateTime.Now.ToString() + " " + "Message delivered to network. ID: " + e.Messageid + "\r\n");
        }

        void mySMSClient_OnMessageAcceptedForDelivery(object sender, DeliveryEventArgs e)
        {
            addToEventList(DateTime.Now.ToString() + " " + "Message accepted for delivery. ID: " + e.Messageid + "\r\n");
        }

        void mySMSClient_OnClientConnectionError(object sender, ErrorEventArgs e)
        {
            addToEventList(DateTime.Now.ToString() + " " + e.ErrorMessage + "\r\n");
        }

        void mySMSClient_OnClientDisconnected(object sender, EventArgs e)
        {
            addToEventList(DateTime.Now.ToString() + " Disconnected from the SMS gateway " + "\r\n");
            BeginInvoke(new clickEvent(bDisconnect_Click), new object[] { this, new EventArgs() });
        }

        void mySMSClient_OnClientConnected(object sender, EventArgs e)
        {
            addToEventList(DateTime.Now.ToString() + " Successfully connected to the SMS gateway " + "\r\n");
        }

        public void Connect()
        {
            bConnect.PerformClick();
        }

        public void Disconnect()
        {
            bDisconnect.PerformClick();
        }

        private void bConnect_Click(object sender, EventArgs e)
        {
            mySMSClient.Username = tbUsername.Text;
            mySMSClient.Password = tbPassword.Text;
            mySMSClient.Host = tbHost.Text;
            mySMSClient.Port = Int32.Parse(tbPort.Text);
            mySMSClient.Connected = true;
            if (!mySMSClient.Connected)
            {
                MessageBox.Show("Could not connecto to SMS Gateway. Reason: " + mySMSClient.getLastErrorMessage());
            }
            else
            {
                bConnect.Enabled = false;
                bDisconnect.Enabled = true;
                tbMessage.Enabled = true;
                tbTo.Enabled = true;
                bSend.Enabled = true;
            }
        }

        private void bDisconnect_Click(object sender, EventArgs e)
        {
            if (mySMSClient.Connected) { mySMSClient.Connected = false; }

            bConnect.Enabled = true;
            bDisconnect.Enabled = false;
            tbMessage.Enabled = false;
            tbTo.Enabled = false;
            bSend.Enabled = false;
        }

        private void bSend_Click(object sender, EventArgs e)
        {
            string msgID = mySMSClient.sendMessage(tbTo.Text, tbMessage.Text);
            tbEvents.Text += (DateTime.Now.ToString() + " Submitting message to the SMS gateway with ID: " + msgID + "\r\n");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            mySMSClient.Connected = false;
        }
    }
}