package msg

import (
	"github.com/name5566/leaf/network/json"
	"github.com/name5566/leaf/network/protobuf"
)

var (
	Processor     = json.NewProcessor()
	ProtobufProcessor = protobuf.NewProcessor()
)

func init() {
	Processor.Register(&C2S_AddUser{})
	Processor.Register(&C2S_Message{})
	Processor.Register(&C2S_Action{})
	Processor.Register(&S2C_Login{})
	Processor.Register(&S2C_Joined{})
	Processor.Register(&S2C_Left{})
	Processor.Register(&S2C_Typing{})
	Processor.Register(&S2C_StopTyping{})
	Processor.Register(&S2C_Message{})
}

type C2S_AddUser struct {
	UserName string
}

type C2S_Message struct {
	Message string
}

type C2S_Action struct {
	// typing
	// stop typing
	Op string
}

type S2C_Login struct {
	NumUsers int
}

type S2C_Joined struct {
	NumUsers int
	UserName string
}

type S2C_Left struct {
	NumUsers int
	UserName string
}

type S2C_Typing struct {
	UserName string
}

type S2C_StopTyping struct {
	UserName string
}

type S2C_Message struct {
	UserName string
	Message  string
}
