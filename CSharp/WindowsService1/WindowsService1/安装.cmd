::set var=123  ʱ��var��ߵ�"="ǰ�����пո�
::@echo off
set var=%windir%\Microsoft.NET\Framework\v2.0.50727\InstallUtil.exe

if NOT EXIST "%var%" (
ECHO ��û�а�װ.net Framework v2.0.50727
PAUSE
) else (

%var% /u WindowsService1.exe 
SC delete �¼���־����ServiceName
%var% WindowsService1.exe 
net start �¼���־����ServiceName
pause
)


