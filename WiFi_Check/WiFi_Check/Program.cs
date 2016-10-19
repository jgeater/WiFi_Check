using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Management;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;

namespace WiFi_Check
{
    class Program
    {
        private const int ERROR_No_Wired_Connection = 0x1;
        static void Main(string[] args)
        {
            
            string macAddress = string.Empty;
            long maxSpeed = 1;
            int eth_count = 0;

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                var temptype = nic.NetworkInterfaceType.ToString();
                Console.WriteLine(
                    "Found MAC Address: " + nic.GetPhysicalAddress() +
                    " Type: " + nic.NetworkInterfaceType);

                string tempMac = nic.GetPhysicalAddress().ToString();
                if (nic.Speed > maxSpeed && temptype == "Ethernet")
                {
                    Console.WriteLine("Wired Network connection Found.");
                    Console.WriteLine(nic.Speed);
                    //Deal with Bluetooth Nic that shows as wired
                    if (nic.Name == "Bluetooth Network Connection")
                    { eth_count--; }

                    eth_count++;

                }
            }
            Console.WriteLine("Search complete!");
            if (eth_count != 0)
            {
                Console.WriteLine("Wired Connection found!");
            }
            else
            {
                Console.WriteLine("Error! No Wired Connection Found!");
                Environment.ExitCode = ERROR_No_Wired_Connection;
            }
            
            //Console.WriteLine(eth_count);
            //Console.ReadLine();

        }
        
    }

}




