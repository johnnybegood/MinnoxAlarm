using System;
using System.Net;
using Microsoft.SPOT;

namespace JBG.Minnox.Alarm.Core
{
    public class ServerConnector
    {
        private readonly string _serverAddress;

        public ServerConnector(string serverAddress)
        {
            _serverAddress = serverAddress;
        }

        public bool Connect()
        {
            try
            {
                using (var request = (HttpWebRequest)WebRequest.Create(string.Concat(_serverAddress, "/Version/")))
                {
                    using (var response = (HttpWebResponse)request.GetResponse())
                    {
                        return response.StatusCode == HttpStatusCode.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                return false;
            }
        }
    }
}