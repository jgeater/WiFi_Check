WiFi_Check.exe 1.0
Written by jgeau in c# requires .net 3.0 or higher

WiFi_Check.exe is just a simple command line tool that does nothing more than return a 0 or 1 as an exit code.
If a wired network connextion is availible it will return 0 and show "Wired Connection found!" in at the command prompt.
If a wired network connextion is not availible it will return 1 and show "Error! No Wired Connection Found!" in at the command prompt.

It may also echo the exit code to the screen.

Usage
This is intended to be used with other programs that may need to know if the dock is plugged in.

example in powershell can run WiFi_Check.exe The look at $LASTEXITCODE

If $LASTEXITCODE is 0 then a wired network connextion is availible
IF $LASTEXITCODE is 1 then a wired network connextion is not availible

In an SCCM task sequence just run the command DockCheck.exe in a "run command line" step
The task sequence will see and exit code of 0 if a wired network connextion is availible
The task sequence will see and exit code of 1 if a wired network connextion is not availible and exit unless you have the "continue on error" option checked.

source code availible upon request 

Basic Design: 
This uses NetworkInterface.NetworkInterfaceType Property described below
https://msdn.microsoft.com/en-us/library/system.net.networkinformation.networkinterface.networkinterfacetype(v=vs.110).aspx
It enumerates all network adapters in the system and looks for one with the Type of "Ethernet" if it finds one and the speed is greater than 1 the it reports a wired network connextion is availible.

