using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System;
using System.Text;
using System.Threading;
using UnityEngine.UI;

public class dataInterface : MonoBehaviour
{
    public GameObject gloveConnText;
    public Toggle leftToggle;
    public Toggle rightToggle;
    private static byte[] result = new byte[1024];
    private static Socket clientSocket; 
    public static string resultStr;
    public static string hand;
    public static string[] fingerDataAll;
    public static float[] fingerData = { 0, 0, 0, 0, 0 };
    private static int receiveLength;
    private static int reconnectCount = 0;
    private static Thread thread=null;
    static float timer = 0;
    private static bool isInternalDriverMode = false;
    // Use this for initialization
    void Start()
    {
        isInternalDriverMode = false;
        reconnectCount = 0;
        //设定服务器IP地址  
        IPAddress ip = IPAddress.Parse("127.0.0.1");
        clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        try
        {
            clientSocket.Connect(new IPEndPoint(ip, 8866)); //配置服务器IP与端口  
            Debug.Log("连接数据服务器成功");
            Text text = gloveConnText.GetComponent<Text>();
            text.text = "正在获取手套状态";
            text.color = Color.yellow;
            reconnectCount = 0;
        }
        catch
        {
            Debug.Log("连接手套数据服务失败！");
            Text text = gloveConnText.GetComponent<Text>();
            text.text = "连接手套数据服务失败！";
        }
        string type = gameObject.GetComponent<gloveUtils>().getGloveType();
        print(type);
        if (type != "No Glove")
        {

            Text text = gloveConnText.GetComponent<Text>();
            text.text = "已连接手套驱动";
            text.color = Color.green;
            isInternalDriverMode = true;
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (clientSocket == null)
            return;
        timer += Time.deltaTime;

        if (timer >= .050)
        {
            receiveMessage();
            timer = 0;

            if (!isInternalDriverMode)
            {
                try
                {
                    string sendMessage = "Unity3D is online";
                    clientSocket.Send(Encoding.UTF8.GetBytes(sendMessage));
                }
                catch
                {
                    closeConnection();
                    Text text = gloveConnText.GetComponent<Text>();
                    text.text = "手套数据服务连接中断！";
                    if (thread == null)
                    {
                        thread = (new Thread(reConnect));
                        thread.Start();
                    }
                }
            }
            
        }
    }

    void receiveMessage()
    {
        if (isInternalDriverMode)
        {
            fingerData = gloveUtils.getGloveData();
        }
        else
        {
            try
            {
                receiveLength = clientSocket.Receive(result);
                resultStr = Encoding.UTF8.GetString(result, 0, receiveLength);
                Debug.Log("接收服务器消息： " + resultStr);
                string[] message = resultStr.Split(new string[] { "##" }, StringSplitOptions.RemoveEmptyEntries);//分割所有数据
                Text text = gloveConnText.GetComponent<Text>();
                if (message[0] == "Unknown")
                {
                    for (int i = 0; i < 5; i++)
                    {
                        fingerData[i] = 0;
                    }
                    text.text = "已连接到服务，未检测到手套";
                    text.color = Color.yellow;
                }
                else
                {
                    string s = message[2];
                    fingerDataAll = s.Split(new string[] { "||" },
                        StringSplitOptions.RemoveEmptyEntries);//分割手套手指数据
                    fingerData[0] = float.Parse(fingerDataAll[0]);
                    fingerData[1] = float.Parse(fingerDataAll[1]);
                    fingerData[2] = float.Parse(fingerDataAll[2]);
                    fingerData[3] = float.Parse(fingerDataAll[3]);
                    fingerData[4] = float.Parse(fingerDataAll[4]);
                    hand = message[1];
                    text.text = "已连接" + message[0] + "(" + hand + ")";
                    text.color = Color.green;
                    reconnectCount = 0;
                }
            }
            catch
            {
                receiveLength = 0;
                resultStr = "";

                closeConnection();
                Text text = gloveConnText.GetComponent<Text>();
                text.text = "手套数据服务连接中断！";
                if (thread == null)
                {
                    thread = (new Thread(reConnect));
                    thread.Start();
                }
            }
        }

        
    }

    void closeConnection()//关闭连接
    {
        if (clientSocket.Connected)
        {
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
        }
    }

    void reConnect()//掉线后重连
    {
        print(reconnectCount);
        if (reconnectCount >= 3)
        {
            return;
        }
        IPAddress ip = IPAddress.Parse("127.0.0.1");
        clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        clientSocket.Connect(new IPEndPoint(ip, 8866));
        reconnectCount++;
    }

}
