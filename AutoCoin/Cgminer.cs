using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;


namespace AutoCoin
{
    public class ApiWorker
    {
        public string Host { get; private set; }
        public Int32 Port { get; private set; }

        public ApiWorker(string host, Int32 port)
        {
            IPAddress ipAddress;
            if (IPAddress.TryParse(host, out ipAddress) && port > 1023 && port < 65536)
            {
                Host = host;
                Port = port;
            }
            else
            {
                throw new Exception("Wrong Host:Port parameters!");
            }
            _cw("Ready");
        }

        private void _cw(string text)
        {
          string x =    "API Worker: " + text;
        }

        public string Request(string cmd) { return _request(cmd); }
        private string _request(string cmd)
        {
            string res = null;
            try
            {
                var client = new TcpClient(Host, Port);

                Stream stream = client.GetStream();
                var streamReader = new StreamReader(stream);

                var cmdByte = Encoding.ASCII.GetBytes(cmd);
                stream.Write(cmdByte, 0, cmdByte.Length);

                res = streamReader.ReadLine();
                stream.Close();
                _cw("Api command `" + cmd + "` executed");
            }
            catch (Exception e)
            {
                _cw("Connection to CGMiner failed! Error: " + e.Message);
                _cw("Exception data: " + e.Data);
            }

            return res;
        }

    }
}