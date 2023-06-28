using System;
using System.Diagnostics;
using System.Net;

namespace RedTeamDevelop
{
    class GeneralInfo
    {
      public string oSystem; //string variable for storing operating system
        public string uName; //string variable for storing username
        public string cDirectory; //string variable for storing current directory
        public string pName; //string variable for storing process name
        public string ePath; //string variable for executable path
        public string ipv4address; //string variable for ipv4adress
	public string hostName;
        public int pId; //int variable for process id
        public bool isAdmin; //bool variable for check if user is admin

        public GeneralInfo(){

            oSystem = Environment.OSVersion.ToString();
            uName = Environment.UserName;
            cDirectory = Environment.CurrentDirectory;
            pName = Process.GetCurrentProcess().ProcessName;
            pId = Process.GetCurrentProcess().Id;
            ePath = Process.GetCurrentProcess().MainModule.FileName;
            hostName = Dns.GetHostName();
            ipv4address = Dns.GetHostByName(hostName).AddressList[2].ToString();
            using var identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            var principal = new System.Security.Principal.WindowsPrincipal(identity);
            isAdmin = principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);
        }
    }
}

