$users = Import-Csv " "
$csvfile = " "

foreach ($user in $users){
    $reportedBy = $user.'Reported by'.Split("@")
    $reportReason = $user.'Reported reason'
    $sentBy = $user.Sender

    if($reportReason -eq 'Phish'){
        $adUser = Get-ADUser -Identity $reportedBy[0] -Properties *
        $userSite = $adUser.CanonicalName.Split("/")

        New-Object -TypeName PSCustomObject -Property @{
            User = $adUser.Name
            Location = $userSite[3]
            ReportedSender = $sentBy
        } | Export-Csv -Path $csvfile -NoTypeInformation -Append

        Write-Host $adUser.Name 'from ' $userSite[2] '/' $userSite[3] 'reported and email from' $sentBy 
    }
}