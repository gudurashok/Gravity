using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMSClient;
using Synergy.Domain.Model;
using Synergy.Domain.Repositories;

namespace Radar.Domain
{
    class Program
    {
        private static void WriteEvent(String myEvent)
        {
            Console.WriteLine(myEvent);
        }

        #region Events
        static void mySMSClient_OnMessageReceived(object sender, DeliveryEventArgs e)
        {
            WriteEvent(DateTime.Now.ToString() + " " + "Message received. Sender address: " + e.Senderaddress + " Message text: " + e.Messagedata + "\r\n");
            processMessageReceived(e);
        }

        private static void processMessageReceived(DeliveryEventArgs e)
        {
            var task = Task.New();
            task.Entity.Name = e.Messagedata;
            task.Save();
        }

        static void mySMSClient_OnMessageDeliveryError(object sender, DeliveryErrorEventArgs e)
        {
            WriteEvent(DateTime.Now.ToString() + " " + "Message could not be delivered. ID: " + e.Messageid + " Error message: " + e.ErrorMessage + "\r\n");
        }

        static void mySMSClient_OnMessageDeliveredToHandset(object sender, DeliveryEventArgs e)
        {
            WriteEvent(DateTime.Now.ToString() + " " + "Message delivered to handset. ID: " + e.Messageid + "\r\n");
        }

        static void mySMSClient_OnMessageDeliveredToNetwork(object sender, DeliveryEventArgs e)
        {
            WriteEvent(DateTime.Now.ToString() + " " + "Message delivered to network. ID: " + e.Messageid + "\r\n");
        }

        static void mySMSClient_OnMessageAcceptedForDelivery(object sender, DeliveryEventArgs e)
        {
            WriteEvent(DateTime.Now.ToString() + " " + "Message accepted for delivery. ID: " + e.Messageid + "\r\n");
        }

        static void mySMSClient_OnClientConnectionError(object sender, ErrorEventArgs e)
        {
            WriteEvent(DateTime.Now.ToString() + " " + e.ErrorMessage + "\r\n");
        }

        static void mySMSClient_OnClientDisconnected(object sender, EventArgs e)
        {
            WriteEvent(DateTime.Now.ToString() + " Disconnected from the SMS gateway " + "\r\n");
        }

        static void mySMSClient_OnClientConnected(object sender, EventArgs e)
        {
            WriteEvent(DateTime.Now.ToString() + " Successfully connected to the SMS gateway " + "\r\n");
        }
        #endregion

        static void Main(string[] args)
        {
            ozSMSClient mySMSClient = new ozSMSClient();
            mySMSClient.OnClientConnected += mySMSClient_OnClientConnected;
            mySMSClient.OnClientDisconnected += mySMSClient_OnClientDisconnected;
            mySMSClient.OnClientConnectionError += mySMSClient_OnClientConnectionError;
            mySMSClient.OnMessageAcceptedForDelivery += mySMSClient_OnMessageAcceptedForDelivery;
            mySMSClient.OnMessageDeliveredToNetwork += mySMSClient_OnMessageDeliveredToNetwork;
            mySMSClient.OnMessageDeliveredToHandset += mySMSClient_OnMessageDeliveredToHandset;
            mySMSClient.OnMessageDeliveryError += mySMSClient_OnMessageDeliveryError;
            mySMSClient.OnMessageReceived += mySMSClient_OnMessageReceived;

            mySMSClient.Username = "admin";
            mySMSClient.Password = "abc123";
            mySMSClient.Host = "127.0.0.1";
            mySMSClient.Port = 9500;

            mySMSClient.Connected = true;

            //mySMSClient.sendMessage("121", "TEST", "vp=" + DateTime.Now + "&ttt=werwerwe rewwe34232 1");

            Console.ReadKey();
            mySMSClient.Connected = false;
        }
    }
}
