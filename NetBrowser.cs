using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;


class NetFrameWorks{

	public string version {get;set;}
	public string UserName {get;set;}
	public string SysDir {get;set;}
	public string OS {get;set;}
	public string TimeZone_ID {get;set;}
	public string TimeZone_DisplayName {get;set;}
	public string TimeZone_StandardName {get;set;}
	public string TimeZone_DaylightName {get;set;}
	public long TickCNT {get;set;}
	public bool bits64 {get;set;}
	public string MachineName {get;set;}
	public string FolderPath {get;set;}
	public string[] LogicDrives{get;set;}
	public DriveInfo[] DrivesInfo{get;set;}



	public void scan(){
		Scan_Enviroment();
		Scan_OSVersions();
		Scan_Hardware();
		Scan_TimeZone();
	}

	private void Scan_TimeZone(){
		TimeZoneInfo localZone = TimeZoneInfo.Local;
		this.TimeZone_ID=localZone.Id;
		this.TimeZone_DisplayName=localZone.DisplayName;
		this.TimeZone_StandardName=localZone.StandardName;
		this.TimeZone_DaylightName=localZone.DaylightName;
		this.TimeZone_ID=localZone.Id;
	        /*Console.WriteLine("Local Time Zone ID: {0}", localZone.Id);
	        Console.WriteLine("   Display Name is: {0}.", localZone.DisplayName);
        	Console.WriteLine("   Standard name is: {0}.", localZone.StandardName);
      		Console.WriteLine("   Daylight saving name is: {0}.", localZone.DaylightName); */
	}

	private void Scan_Hardware(){
		this.LogicDrives=Environment.GetLogicalDrives();
		//DriveInfo[] allDrives = DriveInfo.GetDrives();		
		this.DrivesInfo = DriveInfo.GetDrives();
	}

	private void Scan_OSVersions(){
		var os = Environment.OSVersion;
		//this.version="Testing";
		this.version=os.VersionString.ToString();	
		this.version=os.VersionString.ToString();					
	}



	private void Scan_Enviroment(){
		//check 64bits		
		 //Console.WriteLine("Enviroment: " +  Environment.Is64BitOperatingSystem.ToString());
		 try{
			 if(Environment.Is64BitOperatingSystem==true)
			 {
        			bits64=true;
			  }else{
			        bits64=false;
			  }
		}catch(Exception ex){
			  Console.WriteLine("Enviroment : " +  Environment.Is64BitOperatingSystem.ToString());
			  Console.WriteLine("Error	: " +  ex.ToString());
	
		}
		try{ MachineName=Environment.MachineName.ToString();}catch(Exception ex){
			  Console.WriteLine("Machine Name Error	: " +  ex.ToString());
			  MachineName=ex.ToString();

		}		
		this.TickCNT=Environment.TickCount;
		this.SysDir =Environment.SystemDirectory.ToString();
		this.FolderPath=Environment.GetFolderPath(Environment.SpecialFolder.System).ToString();		
		this.UserName=Environment.UserName;
	}

		
		
}





class Crawler{

	static void Main(string[] args)
	{
		NetFrameWorks myFrm = new NetFrameWorks();
		Write("NetFrameWorks init");	
		myFrm.scan();
		Write("");
		Write("UserName: " + myFrm.UserName.ToString());
		Write("64Bits: " + myFrm.bits64.ToString());
		try{ Write("Machine Name: " + myFrm.MachineName.ToString());} catch(Exception ex){
			  //Console.WriteLine("Machine Name Error	: " +  ex.ToString());
		}
		Write("OS Version: " + myFrm.version);
		Write("Tick Count: " + myFrm.TickCNT.ToString());
		Write("System Directory: " + myFrm.SysDir.ToString());
		Write("Folder Path: " + myFrm.FolderPath.ToString());
		Write("");			
		Write("======================= HARDWARE =================");
		Write("");
		foreach(string strDrive in myFrm.LogicDrives)
		{
			Write("Drive: " + strDrive);
		}
		foreach(DriveInfo d in myFrm.DrivesInfo)
		{
			Write($"Drive" +  d.Name);
	            	Write($"  Drive type: " + d.DriveType);
        		if (d.IsReady == true)
            		{
                		Write($"  Volume label: " + d.VolumeLabel);
                		Write($"  File system: " + d.DriveFormat);
                		Write($"  Available space to current user:" +   (d.AvailableFreeSpace/1048576) + " MB");
                		Write($"  Drive Type:" +  d.DriveType);
			}
		Write("");

                Write(                   "  Total available space:" +
                    (d.TotalFreeSpace/1048576) + " MB");

                Write(
                    "  Total size of drive:      " +
                    (d.TotalSize/1048576) + " MB");
		}
		Write("===================================================");
		Write("");			
		Write("TimeZone    : " + myFrm.TimeZone_ID);
		Write("Display Name : " + myFrm.TimeZone_DisplayName);
		Write("Standard Name : " + myFrm.TimeZone_StandardName);
		Write("Daylight Name : " + myFrm.TimeZone_DaylightName);
		Write("");
		Write("Exit");	
		
	}



	static void Write(string strText){
		Console.WriteLine(strText);
	}
}
