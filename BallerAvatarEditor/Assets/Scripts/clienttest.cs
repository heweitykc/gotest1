using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Net.Sockets;
using SimpleJson;
using Msg;
using Google.Protobuf;

public class clienttest : MonoBehaviour {
    public Text pingmsg;

    RingBuffer<int> ring = new RingBuffer<int>(10);
    TcpClient client;
    string loginmsg = "{\"Hello\": {\"Name\":\"leaf\",\"Tm\":\"[tm]\"}}";

    byte[] recvBuffer = new byte[1024 * 100];   //100k的缓冲
    byte[] recvBuffer2 = new byte[1024 * 100];  //100k的缓冲
    int startpos = 0;
    int endpos = 0;    

    void Start () {
        client = new TcpClient(AddressFamily.InterNetwork);
        client.Connect("127.0.0.1", 3563);
        //client.Connect("192.168.124.157", 3563);
        Application.targetFrameRate = 30;
    }	

	void Update () {
        if (Input.GetKey(KeyCode.Escape)) {
            Application.Quit();
            return;
        }
        if (!client.Connected) return;

       if(Time.frameCount % 10 == 0) {
            //SendPing(((int)(Time.realtimeSinceStartup * 1000)).ToString());
        }

        if (client.Available <= 0) return;
        int recvlen = client.Available;
        if ((startpos + recvlen) >= (recvBuffer.Length - 1)) {
            ResetRecvBuffer();
        }
        client.Client.Receive(recvBuffer, startpos, recvlen, SocketFlags.None);
        endpos += recvlen;

        Parse();
    }

    public void SendLogin()
    {
        C2S_AddUser addu = new C2S_AddUser();
        addu.UserName = "callee";
        Send(addu);
    }

    public void Send(IMessage msg)
    {
        var msgbts = msg.ToByteArray();        
        int len = msgbts.Length;
        var sendbts = new byte[len + 4];    //protobuf: len + message id + message bin
        int id = 0;
        sendbts[0] = (byte)((len+2) >> 8);
        sendbts[1] = (byte)(len+2);
        sendbts[2] = (byte)(id >> 8);
        sendbts[3] = (byte)id;
        Array.Copy(msgbts, 0, sendbts, 4, len);

        client.Client.Send(sendbts);
    }

    public void SendPing(string msg)
    {
        string msgtxt = loginmsg.Replace("[tm]", msg);
        var msgbts = System.Text.ASCIIEncoding.ASCII.GetBytes(msgtxt);
        int len = msgbts.Length;
        var sendbts = new byte[len + 2];

        sendbts[0] = (byte)(len >> 8);
        sendbts[1] = (byte)len;
        Array.Copy(msgbts, 0, sendbts, 2, len);

        client.Client.Send(sendbts);
    }

    void Parse()
    {
        if ((endpos - startpos) < 2)
            return; //至少要2个字节的头部长度

        int len = ((recvBuffer[startpos]) << 8)  + recvBuffer[startpos + 1];
        if ((endpos - startpos) < len){ 
            return;  //数据不足
        }

        startpos += 2;
        Debug.Log("get data len=" + len);

        int msgid = ((recvBuffer[startpos]) << 8) + recvBuffer[startpos + 1];
        S2C_Login s2cmsg = new S2C_Login();
        byte[] protodata = new byte[len-2];
        for (int i = 0; i < protodata.Length; i++) {
            protodata[i] = recvBuffer[4+i];
        }
        s2cmsg.MergeFrom(protodata);
        Debug.Log("nums:"+s2cmsg.NumUsers);

        /*
        string jsonstr = System.Text.ASCIIEncoding.Default.GetString(recvBuffer, startpos, len);        
        var replaydata = SimpleJson.SimpleJson.DeserializeObject<JsonObject>(jsonstr);
        string tm = (replaydata["Hello"] as JsonObject)["Tm"].ToString();
        GetComponent<RoleController>().UpdateControl(tm);
        
        int t = int.Parse(tm);
        float diff = ((Time.realtimeSinceStartup * 1000f) - t) * 0.5f;
        ring.Add((int)diff);

        pingmsg.text = GetAverage(ring.GetList()).ToString() + "ms";
        */

        var newstart = startpos + len;
        if (newstart == endpos) {   //buffer里的数据读完了
            startpos = 0;
            endpos = 0;
            return;
        }
        startpos = newstart;
        Parse();
    }

    //切换2个buffer
    void ResetRecvBuffer()
    {
        Debug.Log("reset buffer");
        var len = endpos - startpos;
        Array.Copy(recvBuffer, startpos, recvBuffer2, 0, endpos - startpos);    //复制剩余的buffer到新数组
        var tmp = recvBuffer2;
        recvBuffer2 = recvBuffer;
        recvBuffer = tmp;
        startpos = 0;
        endpos = len;
    }

    static public int GetAverage(int[] datalist)
    {
        int total = 0;
        foreach (int data in datalist)
            total += data;
        return total / datalist.Length;
    }    
}
