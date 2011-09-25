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
            //using (var request = (HttpWebRequest)WebRequest.Create(string.Concat("http://", _serverAddress, "/Version/")))
            //{
            //    request.Method = "GET";
            //    request.Timeout = 1;

            //    using (var response = request.GetResponse())
            //    {
            //        Debug.Print(response.ToString());
            //    }
            //}

            return false;
        }
    }
}