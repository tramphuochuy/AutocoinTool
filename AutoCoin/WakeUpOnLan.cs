using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoCoin
{
    using System;
    using System.Net.Sockets;
    using System.Globalization;
    using System.Net;

    //we derive our class from a standart one
    public class WakeUpOnLan : UdpClient
    {
        public WakeUpOnLan()
            : base()
        { }
        
        public void SetClientToBrodcastMode()
        {
            if (this.Active)
                this.Client.SetSocketOption(SocketOptionLevel.Socket,
                                          SocketOptionName.Broadcast, 0);
        }



        //MAC_ADDRESS should  look like '013FA049'
        public void WakeFunction(string MAC_ADDRESS)
        {
            WakeUpOnLan client = new WakeUpOnLan();
            client.Connect(new
               IPAddress(0xffffffff),  //255.255.255.255  i.e broadcast
               0x2fff); // port=12287 let's use this one 
            client.SetClientToBrodcastMode();
            //set sending bites
            int counter = 0;
            //buffer to be send
            byte[] bytes = new byte[1024];   // more than enough :-)
            //first 6 bytes should be 0xFF
            for (int y = 0; y < 6; y++)
                bytes[counter++] = 0xFF;
            //now repeate MAC 16 times
            for (int y = 0; y < 16; y++)
            {
                int i = 0;
                for (int z = 0; z < 6; z++)
                {
                    bytes[counter++] =
                        byte.Parse(MAC_ADDRESS.Substring(i, 2),
                        NumberStyles.HexNumber);
                    i += 2;
                }
            }

            //now send wake up packet
            int reterned_value = client.Send(bytes, 1024);
        }
    }

}