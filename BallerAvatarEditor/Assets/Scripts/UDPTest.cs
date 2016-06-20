using UnityEngine;
using System.Collections;
using System.Net.Sockets;
using System.Net;

public class UDPTest : MonoBehaviour {
	string CONNECT = "connect  :";
    string ONLINE =  "online   :";
    string CHAT =    "chat     :";
    string GET =     "get      :";

    string HOST = "107.180.74.209";
    int PORT = 1616;

    IPEndPoint endp;
    int RECV_PORT;

    UdpClient sendClient;
    UdpClient recvClient;

    RingBuffer<int> ring = new RingBuffer<int>(10);

    void Start () {
        RECV_PORT = Random.Range(10000, 30000);
        Debug.Log("接收端口：" + RECV_PORT);
        
        Init();
    }

    void Init()
    {
        string hostname = System.Net.Dns.GetHostName();
        var ip = System.Net.Dns.GetHostEntry(hostname);
        var addr = ip.AddressList;
        endp = new IPEndPoint(addr[addr.Length-1], RECV_PORT);
        recvClient = new UdpClient(endp);
        sendClient = new UdpClient(AddressFamily.InterNetwork);

        string connectstr = CONNECT + "U3D" + ":" + RECV_PORT;
        Send(connectstr);

        StartCoroutine(HeartBeat());
    }

    string pingtxt="";
	void Update () {
        if (recvClient.Available > 0) {
            byte[] bts = recvClient.Receive(ref endp);
            string recvstr = System.Text.UTF8Encoding.UTF8.GetString(bts);
            Debug.Log("Recv: " + recvstr);

            float t = float.Parse(recvstr);
            float diff = ((Time.realtimeSinceStartup * 1000f) - t) * 0.5f;
            ring.Add((int)diff);

            pingtxt = GetAverage(ring.GetList()).ToString() + "ms";
        }
	}

    void OnDestroy()
    {
        recvClient.Close();
    }

    string SendStr="";
    void OnGUI()
    {
        GUILayout.BeginVertical();
        SendStr = GUILayout.TextField(SendStr,GUILayout.Width(200f));
        if (GUILayout.Button("发送数据")) {
            Send(SendStr);
        }
        if (GUILayout.Button("获取在线人数"))
        {
            Send(GET);
        }
        GUILayout.Label("ping: " + pingtxt);
    }

    void Send(string str)
    {
        byte[] bts = System.Text.UTF8Encoding.UTF8.GetBytes(str);
        sendClient.Send(bts, bts.Length, HOST, PORT);
    }

    IEnumerator HeartBeat()
    {
        string pingstr = (Time.realtimeSinceStartup * 1000).ToString();
        Send(ONLINE + pingstr);
       // print("HeartBeat");
        yield return new WaitForSeconds(0.33f);
        StartCoroutine(HeartBeat());
    }

    static public int GetAverage(int[] datalist)
    {
        int total = 0;
        foreach (int data in datalist)
            total += data;
        return total / datalist.Length;
    }
}
