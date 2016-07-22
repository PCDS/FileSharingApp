Taskkill /IM FileSharingAppClient.exe /F
Taskkill /IM FileSharingAppServer.exe /F
cd %~dp0
IF EXIST Releases Powershell.exe  -ExecutionPolicy Bypass "Remove-Item .\Releases -Force -Recurse"
mkdir Releases
Powershell.exe  -ExecutionPolicy Bypass "(New-Object System.Net.WebClient).DownloadFile('https://github.com/PCDS/FileSharingApp/archive/master.zip', 'Releases\currentversion.zip'); "
Powershell.exe  -ExecutionPolicy Bypass "Remove-Item .\* -exclude 'Server.ini','Client.ini','Updater.bat','currentversion.zip','Users.sqlite','ReceivedFiles' -Recurse "
Powershell.exe  -ExecutionPolicy Bypass "Add-Type -AssemblyName System.IO.Compression.FileSystem; [System.IO.Compression.ZipFile]::ExtractToDirectory('Releases\currentversion.zip', 'Releases\currentversion'); "
start Powershell.exe -ExecutionPolicy Bypass "Copy-Item  -Path Releases\currentversion\FileSharingApp-master\* -Destination . -Recurse -force; start cmd.exe ' /c echo UPDATING IS COMPLETE & pause '"
