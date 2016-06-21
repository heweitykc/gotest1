package msg

import (
	//"github.com/name5566/leaf/network/json"
	"github.com/name5566/leaf/network/protobuf"
)

var (
	Processor     = protobuf.NewProcessor()
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
