
IF EXIST Releases Powershell.exe  -ExecutionPolicy Bypass "Remove-Item .\Releases -Force -Recurse"
mkdir Releases
copy Updater.config Releases
Powershell.exe  -ExecutionPolicy Bypass -Command - <Releases\Updater.config
del Releases\Updater.config
start Powershell.exe -ExecutionPolicy Bypass "Copy-Item  -Path Releases\currentversion\PCDS*\* -Destination . -Recurse -force "