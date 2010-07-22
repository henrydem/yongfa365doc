::set var=123  时，var后边的"="前后不能有空格
::@echo off
set var=%windir%\Microsoft.NET\Framework\v2.0.50727\InstallUtil.exe

if NOT EXIST "%var%" (
ECHO 您没有安装.net Framework v2.0.50727
PAUSE
) else (

%var% /u WindowsService1.exe 
SC delete 事件日志服务ServiceName
%var% WindowsService1.exe 
net start 事件日志服务ServiceName
pause
)


