using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class StartCam : MonoBehaviour
{
    public GameObject mainCam;//主摄像机
    public GameObject light0;//灯光
    public GameObject light1;
    public GameObject light2;
    public GameObject light3;
    public GameObject light4;
    public GameObject music1;//音乐
    public GameObject music2;
    public GameObject music3;
    public GameObject music4;
    public GameObject music5;
    public GameObject music6;
    public GameObject music7;
    public GameObject music8;
    public GameObject music9;
    public GameObject music10;
    //public GameObject scorePad;//
    public GameObject score1;
    public GameObject score2;
    public GameObject score3;
    public GameObject Lefthand;
    public GameObject Righthand;
    public Text mwhichMusic;
    public Toggle LeftToggle;
    public Toggle RightToggle;
    public static int whichMusic=0;
    public static string thisMusic;
    //public static int isRightHand ;
    public static float letTheLightsOn = 0;

    void checkHand()//自动检测并勾选toggle
    {
        if (dataInterface.hand == "左")
        {
            LeftToggle.isOn = true;
        }
        else
            if (dataInterface.hand == "右")
        {
            RightToggle.isOn = true;
        }
    }

    void OnEnable()
    {
        mainCam.SetActive(false);
        LeftToggle.isOn = false;
        RightToggle.isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (LeftToggle.isOn == false && RightToggle.isOn == false)
        {
            checkHand();
        }

        

        letTheLightsOn += Time.fixedDeltaTime;
        transform.Rotate(new Vector3(0, 20 * Time.fixedDeltaTime, 0));
        if (letTheLightsOn >= .3)
        {
            letTheLightsOn = 0;
            light0.SetActive(true);
            light1.SetActive(true);
            light2.SetActive(true);
            light3.SetActive(true);
            light4.SetActive(true);
            light0.GetComponent<Light>().color = Color.white;
            light1.GetComponent<Light>().color = Color.white;
            light2.GetComponent<Light>().color = Color.white;
            light3.GetComponent<Light>().color = Color.white;
            light4.GetComponent<Light>().color = Color.white;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            int i = Random.Range(1, 11);
            //int j = Random.Range(0, 2);
            //switch (j)
            //{
            //    case 0: SelectLeftHand(); break;
            //    case 1: SelectRightHand(); break;
            //}
            Invoke("Playmusic"+i, 0.01f);
        }
    }

    void StartGame()
    {
        checkHandSelect();
        mainCtrl.isGameStart = 1;
        mainCam.SetActive(true);
        Reset();
        
        gameObject.SetActive(false);
        Invoke("setMusicName", 0.05f);
    }
    void setMusicName()
    {
        thisMusic = mwhichMusic.text;
    }

    void Reset()//重置游戏数据
    {
        mainCtrl.targetNumber = 6;
        mainCtrl.getPoints = 0;
        mainCtrl.missPoints = 0;
        mainCtrl.wrong = 0;
        mainCtrl.TimeOut = 0;
        mainCtrl.moveSpeed = 2;
        mainCtrl.timer = 0;
        mainCtrl.gameTimer = 0;
    }

    void checkHandSelect()//如果未选中左右手默认右手
    {
        if (LeftToggle.isOn == false && RightToggle.isOn == false)
            SelectRightHand();
    }

    public void SelectLeftHand()
    {
        mainCam.GetComponent<Camera>().depth = -1;
        Lefthand.SetActive(true);
        Righthand.SetActive(false);
        mainCtrl.isRightHand = 0;
    }

    public void SelectRightHand()
    {
        mainCam.GetComponent<Camera>().depth = 1;
        Lefthand.SetActive(false);
        Righthand.SetActive(true);
        mainCtrl.isRightHand = 1;
    }

    public void Playmusic1()
    {
        music1.SetActive(true);
        mainCtrl.gameTime = 120 + 24;
        StartGame();
        mwhichMusic.text = "《Summer》";
    }
    public void Playmusic2()
    {
        music2.SetActive(true);
        mainCtrl.gameTime = 120 + 45;
        StartGame();
        mwhichMusic.text = "《Spring》";
    }
    public void Playmusic3()
    {
        music3.SetActive(true);
        mainCtrl.gameTime = 240 + 10;
        StartGame();
        mwhichMusic.text = "《Always with me》";
    }
    public void Playmusic4()
    {
        music4.SetActive(true);
        mainCtrl.gameTime = 120 + 53;
        StartGame();
        mwhichMusic.text = "《River flows in you》";
    }
    public void Playmusic5()
    {
        music5.SetActive(true);
        mainCtrl.gameTime = 180 + 10;
        StartGame();
        mwhichMusic.text = "《少女的祈祷钢琴曲》";
    }
    public void Playmusic6()
    {
        music6.SetActive(true);
        mainCtrl.gameTime = 180 + 14;
        StartGame();
        mwhichMusic.text = "《流动的城市》";
    }
    public void Playmusic7()
    {
        music7.SetActive(true);
        mainCtrl.gameTime = 180 + 42;
        StartGame();
        mwhichMusic.text = "《月光水岸》";
    }
    public void Playmusic8()
    {
        music8.SetActive(true);
        mainCtrl.gameTime = 120 + 52;
        StartGame();
        mwhichMusic.text = "《Smile Smile Smile》";
    }
    public void Playmusic9()
    {
        music9.SetActive(true);
        mainCtrl.gameTime = 180 + 12;
        StartGame();
        mwhichMusic.text = "《Gentlemen》";
    }
    public void Playmusic10()
    {
        music10.SetActive(true);
        mainCtrl.gameTime = 120 + 22;
        StartGame();
        mwhichMusic.text = "《Seawind》";
    }

}
