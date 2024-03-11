 #FTP Server Information - SET VARIABLES
    $dockerhost = $global:dockerhost
    If(!$dockerhost){
        $dockerhost = "localhost"
    }
    
    $ftp = "ftp://${dockerhost}:21"
    echo $ftp 
    $user = 'user' 
    $pass = 'blabla#123'    
    $target = Join-Path -Path "$PSScriptRoot" -ChildPath "../src/Frontend/src/app/server"

    #SET CREDENTIALS
    $credentials = new-object System.Net.NetworkCredential($user, $pass)

function DownloadFtpDirectory($url, $credentials, $localPath)
{
    $listRequest = [Net.WebRequest]::Create($url)
    $listRequest.Method =
        [System.Net.WebRequestMethods+Ftp]::ListDirectoryDetails
    $listRequest.Credentials = $credentials
    
    $lines = New-Object System.Collections.ArrayList

    $listResponse = $listRequest.GetResponse()
    $listStream = $listResponse.GetResponseStream()
    $listReader = New-Object System.IO.StreamReader($listStream)
    while (!$listReader.EndOfStream)
    {
        $line = $listReader.ReadLine()
        $lines.Add($line) | Out-Null
    }
    $listReader.Dispose()
    $listStream.Dispose()
    $listResponse.Dispose()

    foreach ($line in $lines)
    {
        $tokens = $line.Split(" ", 9, [StringSplitOptions]::RemoveEmptyEntries)
        $name = $tokens[8]
        $permissions = $tokens[0]

        $localFilePath = Join-Path $localPath $name
        $fileUrl = ($url + $name)

        if ($permissions[0] -eq 'd')
        {
            if (!(Test-Path $localFilePath -PathType container))
            {
                Write-Host "Creating directory $localFilePath"
                New-Item $localFilePath -Type directory | Out-Null
            }

            DownloadFtpDirectory ($fileUrl + "/") $credentials $localFilePath
        }
        else
        {
            Write-Host "Downloading $fileUrl to $localFilePath"

            $downloadRequest = [Net.WebRequest]::Create($fileUrl)
            $downloadRequest.Method =
                [System.Net.WebRequestMethods+Ftp]::DownloadFile
            $downloadRequest.Credentials = $credentials

            $downloadResponse = $downloadRequest.GetResponse()
            $sourceStream = $downloadResponse.GetResponseStream()
            $targetStream = [System.IO.File]::Create($localFilePath)
            $buffer = New-Object byte[] 10240
            while (($read = $sourceStream.Read($buffer, 0, $buffer.Length)) -gt 0)
            {
                $targetStream.Write($buffer, 0, $read);
            }
            $targetStream.Dispose()
            $sourceStream.Dispose()
            $downloadResponse.Dispose()
        }
    }
}
Remove-Item "$target/api/*" -Recurse -Force 
Remove-Item "$target/model/*" -Recurse -Force 
try{
DownloadFtpDirectory -url "$ftp/api/" -credentials $credentials -localPath "$target/api"
DownloadFtpDirectory -url "$ftp/model/" -credentials $credentials -localPath "$target/model"
}catch{
Write-Host "An error occurred"
$_
}

