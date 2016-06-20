SET GOPATH=%~dp0

go get github.com/golang/protobuf/proto
go install github.com/golang/protobuf/protoc-gen-go
go get gopkg.in/mgo.v2
go get github.com/go-sql-driver/mysql

go get github.com/name5566/leaf