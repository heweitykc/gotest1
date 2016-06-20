package gate

import (
	"server/game"
	"server/msg"
)

func init() {
	msg.Processor.SetRouter(&msg.C2S_AddUser{}, game.ChanRPC)
	msg.Processor.SetRouter(&msg.C2S_Message{}, game.ChanRPC)
	msg.Processor.SetRouter(&msg.C2S_Action{}, game.ChanRPC)
}
