package model
 
type Args struct {
        A, B int
}

func (arg *Args) Init(a int, b int){
	arg.A = a
	arg.B = b
}