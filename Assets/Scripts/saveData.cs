using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

public class saveData : MonoBehaviour
{
    public GameObject toastTip;
    public static GameObject toast;
    private static byte[] result = new byte[1024];
    private static string messageReceive;
    private static string allMessage;
    //private static Socket clientSocket;
    public void Start()
    {
        toast = toastTip;
    }

    public void saveButton()
    {
        writeData();
    }

    public static void writeData()
    {
        string hand;
        string totalData;
        if (mainCtrl.isRightHand == 1)
        {
            hand = "右手数据\r\n";
        }
        else
        {
            hand = "左手数据\r\n";
        }
        string thisMusic = "曲目：" + StartCam.thisMusic + "\r\n";
        string curvature = "弯曲度检测下限" + mainCtrl.curvatureValue*90 + "°\r\n";
        string speed;
        switch((int)(mainCtrl.KeyBirthTime))
        {
            case 5:speed = "速度：3倍\r\n"; break;
            case 8: speed = "速度：3倍\r\n"; break;
            case 10: speed = "速度：3倍\r\n"; break;
            default: speed = "速度：未设置\r\n"; break;
        }
        string getpoint = "总得分：" + mainCtrl.getPoints.ToString() + "\r\n";
        string missPoints = "总失分：" + mainCtrl.missPoints.ToString() + "\r\n";
        string wrong = "总失误：" + mainCtrl.wrong.ToString() + "\r\n";
        string finger0 = "finger0失分：" + mainCtrl.finger0miss.ToString() + "\r\n";
        string finger1 = "finger1失分：" + mainCtrl.finger1miss.ToString() + "\r\n";
        string finger2 = "finger2失分：" + mainCtrl.finger2miss.ToString() + "\r\n";
        string finger3 = "finger3失分：" + mainCtrl.finger3miss.ToString() + "\r\n";
        string finger4 = "finger4失分：" + mainCtrl.finger4miss.ToString() + "\r\n";
        totalData = thisMusic+ curvature + speed + hand + getpoint + missPoints + wrong + finger0 + finger1 + finger2 + finger3 + finger4+ messageReceive;
        savedata(totalData);
    }

    public static void savedata(string s)//存档
    {
        string dir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        DateTime dt = DateTime.Now;
        string saveName = dt.ToString("yyyyMMddHHmmss");
        string sPath = dir + "\\钢琴游戏数据\\";
        if (!Directory.Exists(sPath))
        {
            Directory.CreateDirectory(sPath);
        }
        string fullSavePath = sPath + "游戏数据" + saveName + ".txt";
        Debug.Log(fullSavePath);
        FileStream fs1 = new FileStream(fullSavePath, FileMode.Create, FileAccess.Write);
        fs1.Close();
        StreamWriter sw = File.AppendText(fullSavePath);
        string time = dt.ToString() + "\r\n";
        sw.WriteLine(time + s);
        sw.Close();
        toast.SetActive(true);


    }
    public void showToast()
    {
        toastTip.SetActive(true);
    }

    public void hideToast()
    {
        toastTip.SetActive(false);
    }
}
