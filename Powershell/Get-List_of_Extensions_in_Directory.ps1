$files = Get-ChildItem -Recurse | select Name | sort Name
$extList = @()
$date = get-date -Format yyyyMMdd
$machineName = Get-ComputerInfo

foreach($file in $files){
    $last = $file.Name
    $last = $last.Split('.') 
    $extension = $last[-1].ToString()

    if($extList -contains $extension) {
        #Write-Host Extension $extension is already in List
    }
    else{
        $extList += $extension
        Write-Host Added the extension $extension to the list!
        #Write-host $extList
    }
    
    #Write-Host $extension[-1]
}
$txtFile = -join($machineName.CsName,"_ext_list_",$date.ToString(),".txt")
$extList | Out-File C:\Users\rarellano_pa\Documents\$txtFile