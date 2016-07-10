SET GOPATH=%~dp0
go install dbserver
cd bin 
dbserver.exe

pause