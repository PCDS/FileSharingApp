
IF EXIST Releases Powershell.exe  -ExecutionPolicy Bypass "Remove-Item .\Releases -Force -Recurse"
mkdir Releases
Powershell.exe  -ExecutionPolicy Bypass "(New-Object System.Net.WebClient).DownloadFile('https://github.com/PCDS/FileSharingApp/zipball/master', 'Releases\currentversion.zip'); "
Powershell.exe  -ExecutionPolicy Bypass "(New-Object System.Net.WebClient).DownloadFile('https://pcds.github.io/FileSharingApp/versioninfo.html', 'Releases\currentversion.txt'); "
Powershell.exe  -ExecutionPolicy Bypass "Add-Type -AssemblyName System.IO.Compression.FileSystem; [System.IO.Compression.ZipFile]::ExtractToDirectory('Releases\currentversion.zip', 'Releases\currentversion'); "
Powershell.exe  -ExecutionPolicy Bypass "Remove-Item .\* -exclude 'Server.ini','Client.ini','Updater.bat','Releases' "
start Powershell.exe -ExecutionPolicy Bypass "Copy-Item  -Path Releases\currentversion\PCDS*\* -Destination . -Recurse -force "