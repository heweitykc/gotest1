package main
 
import (
        "net/rpc"
        "net/http"
        "log"
        "net"
      //  "time"
	    "model"
)
 
type Arith int
 
func (t *Arith) Multiply(args *model.Args, reply *([]string)) error {
		print("Multiply called!!!")
        *reply = append(*reply, "test")
        return nil
}
 
func main() {
        arith := new(Arith)
 
        rpc.Register(arith)
        rpc.HandleHTTP()
         
        l, e := net.Listen("tcp", ":3456")
        if e != nil {
                log.Fatal("listen error:", e)
        }
		http.Serve(l, nil)
		/*
        go http.Serve(l, nil)
        time.Sleep(5 * time.Second)
 
        client, err := rpc.DialHTTP("tcp", "127.0.0.1" + ":1234")
        if err != nil {
                log.Fatal("dialing:", err)
        }
         
        args := &Args{7,8}
        reply := make([]string, 10)
        err = client.Call("Arith.Multiply", args, &reply)
        if err != nil {
                log.Fatal("arith error:", err)
        }
        log.Println(reply)
		*/
}