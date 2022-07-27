<#
.SYNOPSIS
A toolset of commonly used features for an individual machine.

.DESCRIPTION
Enter the computer name and the script will first look to see if the machine is online.
After that, it'll ask you if you want to continue with that machine.
If you press 'Y', You'll get a list of things you can do.

.NOTES
Very simple script for information gathering.
#>

cls

DO
{
    # Ask for computer number
    $pcname = Read-Host "Enter computer name"
    $pcname = $pcname.ToUpper()
        
    # Ping Machine to see offline/online status
    Write-Host "Checking to see if machine is online..."
    if (Test-Connection $pcname -Quiet) {
        cls
        Write-Host "$pcname is Online."
        $status = 1;
    } else { 
        cls
        $status = 0;
    }

    # Verify that they want to continue with that device
    if ($status -eq 1) {
        $namecheck = Read-Host "Are you sure you want to work with $pcname ? [Y]es, [N]o, or [Q]uit"
        if ($namecheck -eq 'Q') {
            Exit
        }
    }
    else {
        $namecheck = Read-Host "Cannot connect to $pcname at this moment. Press [N] to try a different computer name or [Q] to exit"
        if ($namecheck -eq 'Q') {
            Exit
        }
    }
    
} While ($namecheck -eq 'N')


DO
{
    cls
   

    Write-Host "What would you like to do with $pcname?"
    
    Write-Host "1 - Send Message"
    Write-Host "2 - View Eventlog"
    Write-Host "3 - Windows Version"
    Write-Host "4 - Logged on User"
    Write-Host "5 - Active Directory Information"
    Write-Host "6 - Remote Restart"
    Write-Host "7 - Get Service Tag"
    Write-Host "8 - Get CPU Info"
    
    Write-Host "Q - Quit"

    $choice = Read-Host "Enter Selection"

    # 1 - Send Message
    if ($choice -eq '1') {

        $message = Read-Host -Prompt 'Enter message'
        Invoke-WmiMethod -Class win32_process -ComputerName $pcname -Name create -ArgumentList "C:\Windows\System32\msg.exe * $message"
        Write-Host "Message sent"

        [void](Read-Host "Press Enter to continue...")
    }

    # 2 - View Event Log
    elseif ($choice -eq '2') {
        
        # Check if service is running
        $remreg = Get-Service -ComputerName $pcname -Name RemoteRegistry
        $remregstatus = $remreg.Status
        $remregstarttype = $remreg.StartType

        if ($remregstatus -eq "Running") {
            cls
            Write-Host "Remote Registry Service is already running."
        }
        elseif ($remregstarttype -ne "Automatic") {
            cls
            Get-Service -ComputerName $pcname -Name RemoteRegistry | Set-Service -StartupType Automatic

            Write-Host "Remote Registry Service start type has been set to " $remregstatus
            Write-Host "Remote Registry Service is currently " $remregstarttype
        }
        else {
            $remregstatus
        }

        [void](Read-Host "Press Enter to continue...")
        do {
            cls
            Write-Host "1 - Application Logs"
            Write-Host "2 - Security Logs"
            Write-Host "3 - System Logs"

            Write-Host "Q - Quit"

            $logtypechoice = Read-Host "Select Event Log or [Q] to quit"
            
            if ($logtypechoice -eq '1') { 
                $logtype = "Application"
            }
            elseif ($logtypechoice -eq '2') { 
                $logtype = "Security"
            }
            elseif ($logtypechoice -eq '3') { 
                $logtype = "System"
            }
            elseif ($logtypechoice -eq 'q') {
                break
            }

            do {
                cls
                
                Write-Host "Getting Logs from $logtype"
                Write-Host "1 - Last 5 Error logs (Only for Application and System Logs)"
                Write-Host "2 - Last 5 Warning logs(Only for Application and System Logs)"
                Write-Host "3 - Last 5 Info logs(Only for Application and System Logs)"
                Write-Host "4 - Last 25 Total Entries"
                
                Write-Host "Q - Quit"
                $logview = Read-Host "Select which logs to view"

                if ($logview -eq '1') {
                    cls
                    Write-Host "Fetching the last 5 Error entries from the $logtype log..."
                    $logrequest = Get-EventLog -ComputerName $pcname -LogName $logtype -EntryType Error -Newest 5
                }
                elseif ($logview -eq '2') {
                    cls
                    Write-Host "Fetching the last 5 Warning entries from the $logtype log..."
                    $logrequest = Get-EventLog -ComputerName $pcname -LogName $logtype -EntryType Warning -Newest 5
                }
                elseif ($logview -eq '3') {
                    cls
                    Write-Host "Fetching the last 5 Informational entries from the $logtype log..."
                    $logrequest = Get-EventLog -ComputerName $pcname -LogName $logtype -EntryType Information -Newest 5
                }
                elseif ($logview -eq '4') {
                    cls
                    Write-Host "Fetching the last 25 total entries from the $logtype log..."
                    $logrequest = Get-EventLog -ComputerName $pcname -LogName $logtype -Newest 25
                }
                elseif ($logview -eq 'q') {
                    break
                }

                $logcount = 0

                foreach ($request in $logrequest){
                    $logcount = $logcount + 1
                    Write-Host "`nEntry " $logcount
                    Write-Host "~~~~~~~~~"
                    
                    Write-Host $request.EventID 
                    Write-Host $request.TimeGenerated 
                    Write-Host $request.Message
                }
                [void](Read-Host "Press Enter to continue...")

            } while ($logview -ne 'Q')

        } while ($logtypechoice -ne 'Q')

        # Disable Remote Registry when done
        Get-Service -ComputerName $pcname -Name RemoteRegistry | Set-Service -StartupType Disabled 
        Get-Service -ComputerName $pcname -Name RemoteRegistry | Stop-Service

    }

    # 3 - Windows Version
    elseif ($choice -eq '3') {
        cls
        $winversion = Get-WmiObject -Class win32_OperatingSystem -ComputerName $pcname
        $winversion.Version
        
        [void](Read-Host "Press Enter to continue...")
    }

    # 4 - Logged On User
    elseif ($choice -eq '4') {
        $loggedonuser = Get-WmiObject -ComputerName $pcname -Class win32_computersystem
        $loggedonuser.username

        [void](Read-Host "Press Enter to continue...")
    }

    # 5 - AD info
    elseif ($choice -eq '5') {
        Get-ADComputer -Identity $pcname -Properties *
        
        [void](Read-Host "Press Enter to continue...")
    }

    # 6 - Remote Restart
    elseif ($choice -eq '6') {
       $areyousure = Read-Host "Are you sure you want to restart $pcname ? Y/N"
       if ($areyousure -eq 'Y') {
        
       }
    }

    # 7 - Service Tag
    elseif ($choice -eq '7') {
        $biosinfo = Get-WmiObject -ComputerName $pcname -Class win32_bios
        $biosinfo.SerialNumber
        
        [void](Read-Host "Press Enter to continue...")
    }

    # 8 - Get CPU Info
    elseif ($choice -eq'8') {
        $cpuinfo = Get-WmiObject -ComputerName $pcname -Class Win32_processor
        $cpuinfo.Name

        [void](Read-Host "Press Enter to continue...")
    }
    
    # Q - Quit Message
    elseif ($choice -eq 'q') {
        cls
        Write-Host "Thank you for using this script! Enjoy your day!"

        [void](Read-Host "Press Enter to continue...")
        cls
    }

    else {
        cls
        Write-Host "That is not a valid entry. Try again."

        [void](Read-Host "Press Enter to continue...")
    }

} While ($choice -ne 'q')