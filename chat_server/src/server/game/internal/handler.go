package internal

import (
	"net/rpc"
	"fmt"
	"github.com/name5566/leaf/gate"
	"reflect"
	"server/msg"
	"time"
	"log"
)

const maxMessages = 50

type Args struct {
        A, B int
}

var (
	messages [maxMessages]struct {
		userName string
		message  string
	}
	messageIndex int
	rpcClient *rpc.Client
)

var loc = time.FixedZone("", 8*3600)

func handleMsg(m interface{}, h interface{}) {
	skeleton.RegisterChanRPC(reflect.TypeOf(m), h)
}

func init() {
	rpcclient, rcperr := rpc.DialHTTP("tcp", "127.0.0.1" + ":1234")
	if rcperr != nil {
			log.Fatal("dialing:", rcperr)
	}
	rpcClient = rpcclient
	handleMsg(&msg.C2S_AddUser{}, handleAddUser)
	handleMsg(&msg.C2S_Message{}, handleMessage)
	handleMsg(&msg.C2S_Action{}, handleAction)
}

func handleAddUser(args []interface{}) {
	m := args[0].(*msg.C2S_AddUser)
	a := args[1].(gate.Agent)

	a.SetUserData(m.UserName)

	for i := 0; i < maxMessages; i++ {
		index := (messageIndex + i) % maxMessages
		pm := &messages[index]
		if pm.message == "" {
			continue
		}
		a.WriteMsg(&msg.S2C_Message{
			UserName: pm.userName,
			Message:  pm.message,
		})
	}

	a.WriteMsg(&msg.S2C_Login{
		NumUsers: int32(len(users)),
	})
	broadcastMsg(&msg.S2C_Joined{
		UserName: m.UserName,
		NumUsers: int32(len(users)),
	}, a)
	
	rpcargs := &Args{7,8}
	reply := make([]string, 10)
	err := rpcClient.Call("Arith.Multiply", rpcargs, &reply)
	if err != nil {
			log.Fatal("arith error:", err)
	}
    log.Println(reply)
}

func handleMessage(args []interface{}) {
	m := args[0].(*msg.C2S_Message)
	a := args[1].(gate.Agent)

	userName, ok := a.UserData().(string)
	if !ok {
		return
	}

	now := time.Now().In(loc)
	message := fmt.Sprintf("@%02d:%02d %s", now.Hour(), now.Minute(), m.Message)

	pm := &messages[messageIndex]
	pm.userName = userName
	pm.message = message
	messageIndex++
	if messageIndex >= maxMessages {
		messageIndex = 0
	}

	broadcastMsg(&msg.S2C_Message{
		UserName: userName,
		Message:  message,
	}, a)
}

func handleAction(args []interface{}) {
	m := args[0].(*msg.C2S_Action)
	a := args[1].(gate.Agent)

	userName, ok := a.UserData().(string)
	if !ok {
		return
	}

	switch m.Op {
	case "typing":
		broadcastMsg(&msg.S2C_Typing{
			UserName: userName,
		}, a)
	case "stop typing":
		broadcastMsg(&msg.S2C_StopTyping{
			UserName: userName,
		}, a)
	}
}
