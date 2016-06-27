package common
 
import (
	"net/rpc"
	"log"
	"model"
)

var (
	rpcClient *rpc.Client
)

func init() {
	rpcclient, rcperr := rpc.DialHTTP("tcp", "127.0.0.1" + ":3456")
		if rcperr != nil {
			log.Fatal("dialing:", rcperr)
	}
	rpcClient = rpcclient
}

func Multiply(rpcargs *model.Args){
	reply := make([]string, 10)
	err := rpcClient.Call("Arith.Multiply", rpcargs, &reply)
	if err != nil {
			log.Fatal("arith error:", err)
	}
    log.Println(reply)
}