protoc --csharp_out c#_out/ *.proto
protoc --plugin=protoc-gen-go=protoc-gen-go.exe --go_out go_out/ *.proto
pause