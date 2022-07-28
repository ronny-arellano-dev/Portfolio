# Enter read path
$users = Import-Csv "C:\Users\USERNAME\Desktop\MFA_Disabled_Users.csv"

# Enter save path
$csvfile = "C:\Users\USERNAME\Desktop\users_test_8.csv"

# Cycle through users in CSV
foreach($user in $users){
    
    $dName = $user.UserPrincipalName.Split("@")
    $userUPN = $user.UserPrincipalName
    
    #Write-Host $dName[0]
    $domain = $dName[1].ToLower()
    
    if($dName[1] -eq "DOMAIN One"){
        New-Object -TypeName PSCustomObject -Property @{
            DisplayName = $userUPN
            Title = "Not in XXX"
            EmailAddress = "Not in XXX"
            CanonicalName = "Not in XXX"
            Enabled = ""
        } | Export-Csv -Path $csvfile -NoTypeInformation -Append       
    }
    elseif($dName[1] -eq "DOMAIN Two"){
        New-Object -TypeName PSCustomObject -Property @{
            DisplayName = $userUPN
            Title = "Not in XXX"
            EmailAddress = "Not in XXX"
            CanonicalName = "Not in XXX"
            Enabled = ""
        } | Export-Csv -Path $csvfile -NoTypeInformation -Append 
    }
    else {
        Write-Host $dName[0] is an XXX account.
        $getinfo = Get-ADUser -Filter {UserPrincipalName -eq $userUPN} -Properties * | select DisplayName,Title,EmailAddress,CanonicalName,Enabled
        $getinfo | Export-Csv -Path $csvfile -Append
    }
}
