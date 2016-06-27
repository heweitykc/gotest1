SET GOPATH=%~dp0
go install server
go install dbserver
cd bin 
start dbserver.exe
start server.exe
pause