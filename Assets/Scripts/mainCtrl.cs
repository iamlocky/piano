using UnityEngine;
using UnityEngine.UI;



public class mainCtrl : MonoBehaviour
{
    public GameObject key1;//光键预设
    public GameObject key2;
    public GameObject key3;
    public GameObject key4;
    public GameObject key0;//---
    public GameObject imgL;//左右手提示图
    public GameObject imgR;
    //public GameObject startText;
    public GameObject startCam;//启动界面摄像机
    public GameObject miss;
    public GameObject scorePad;//记分板
    public GameObject Score;
    public GameObject missScore;
    public GameObject Wrong;//---
    public GameObject startPanel;//启动文字
    public Text mspeed;
    public Scrollbar scrollbar;//进度条
    public Slider curvature;//弯曲度控制条
    public static GameObject music;//当前音乐
    public static GameObject newkey1;//食指
    public static GameObject newkey2;
    public static GameObject newkey3;
    public static GameObject newkey4;//小拇指
    public static GameObject newkey0;//大拇指
    public static GameObject light0;//提示灯光
    public static GameObject light1;
    public static GameObject light2;
    public static GameObject light3;
    public static GameObject light4;//---
    public static GameObject target;//当前目标光键
    public static GameObject maincamera;//主摄像机-右
    public static GameObject missAudio;//失分提示音
    public static Camera camera;//当前摄像机
    public static int isGameStart = 0;//是否开始游戏
    public static int isRightHand = 1;//是否右手
    public static int targetNumber = 666;//当前目标光键序号（0~4）
    public static int getPoints = 0;//得分
    public static int missPoints = 0;//失分
    public static int wrong = 0;//失误
    public static int finger0miss = 0;//各手指失分情况
    public static int finger1miss = 0;
    public static int finger2miss = 0;
    public static int finger3miss = 0;
    public static int finger4miss = 0;//---
    public static int timeMultiple = 1;//按下持续时间倍数
    public static int TimeOut = 0;//游戏时间到
    public static float LightOnTime = .3f;//灯光持续时间
    public static float moveSpeed;//光键移动速度
    public static float timer = 0;//计时器
    public static float keyPressTimer = 0;//手指按下计时器
    public static float KeyBirthTime = 5;//生成光键时间间隔
    public static float gameTime = 0;//游戏时间
    public static float gameTimer = 0;//当前游戏时间进度
    public static float curvatureValue = .5f;
    Color keydownColor = new Color(15 / 255f, 56 / 255f, 1, 1);//触发按键灯光
    Color BingoColor = new Color(0, 180 / 255f, 24 / 255f, 1);//正确灯光

    

    void Start()
    {
        startPanel.SetActive(false);
        maincamera = gameObject;
        camera = gameObject.GetComponent<Camera>();
        light0.SetActive(false);//关灯
        light1.SetActive(false);
        light2.SetActive(false);
        light3.SetActive(false);
        light4.SetActive(false);
        Reset();//重置数据
        missAudio = miss;//加载音频
        moveSpeed = (8.15f / KeyBirthTime);
        InstantiateNewKey(0);
        Debug.Log(moveSpeed + "\r\n" + KeyBirthTime);
    }
    void OnEnable()//unity重新开始游戏时调用
    {
        if (isGameStart == 0)
            return;
        Start();
    }
    public void changeCurvature()//修改弯曲度
    {
        curvatureValue = curvature.value;
        print(curvatureValue);
    }

    void Reset()
    {
        targetNumber = 666;
        getPoints = 0;
        missPoints = 0;
        wrong = 0;
        TimeOut = 0;
        //moveSpeed = 2;
        timer = 0;
        gameTimer = 0;
    }

    public void setKeyBirthTimeX1()
    {
        KeyBirthTime = 10;
        mspeed.text = "1倍";
    }
    public void setKeyBirthTimeX2()
    {
        KeyBirthTime = 8;
        mspeed.text = "2倍";
    }
    public void setKeyBirthTimeX3()
    {
        KeyBirthTime = 5;
        mspeed.text = "3倍";
    }

    void Update()
    {
        gameTimer += Time.deltaTime;//游戏运行时间
        timer += Time.deltaTime;
        if (TimeOut != 1)
        {
            float size = gameTimer / gameTime;//进度条
            if (size <= 1)
            {
                scrollbar.size = size;
            }
        }

        Score.GetComponent<Text>().text = getPoints.ToString();//得分
        missScore.GetComponent<Text>().text = missPoints.ToString();//失分
        Wrong.GetComponent<Text>().text = wrong.ToString();//失误
        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    camera.depth = -1;
        //    imgL.SetActive(true);
        //    imgR.SetActive(false);
        //    Debug.Log("Left hand");
        //}
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    camera.depth = 1;
        //    imgL.SetActive(false);
        //    imgR.SetActive(true);
        //    Debug.Log("Right hand");
        //}
        if (dataInterface.fingerData[0]>= curvatureValue)//大拇指
        {
            light0.SetActive(false);
            light0.GetComponent<Light>().color = keydownColor;
            light0.SetActive(true);
            Debug.Log("key0");
            if (target != null && targetNumber == 0)
            {
                light0.GetComponent<Light>().color = BingoColor;
                keyPressTimer += Time.deltaTime;
                Debug.Log(keyPressTimer+"\n"+(timeMultiple / 2f));
                if (keyPressTimer>= (timeMultiple / 2f))
                {
                    Destroy(target);
                    timer = KeyBirthTime - 0.5f;
                    getPoints++;
                    keyPressTimer = 0;
                    light0.GetComponent<Light>().color = BingoColor;
                }
            }
            else
            {
                //wrong++;
            }
        }
        if (dataInterface.fingerData[1] >= curvatureValue)//食指
        {
            light1.SetActive(false);
            light1.GetComponent<Light>().color = keydownColor;
            light1.SetActive(true);
            Debug.Log("key1");
            if (target != null && targetNumber == 1)
            {
                light1.GetComponent<Light>().color = BingoColor;
                keyPressTimer += Time.deltaTime;
                Debug.Log(keyPressTimer + "\n" + (timeMultiple / 2f));
                if (keyPressTimer >= (timeMultiple / 2f))
                {
                    Destroy(target);
                    timer = KeyBirthTime - 0.5f;
                    getPoints++;
                    keyPressTimer = 0;
                    light1.GetComponent<Light>().color = BingoColor;
                }
            }
            else
            {
                //wrong++;
            }
        }
        if (dataInterface.fingerData[2] >= curvatureValue)//中指
        {
            light2.GetComponent<Light>().color = keydownColor;
            light2.SetActive(true);
            Debug.Log("key2");
            if (target != null && targetNumber == 2)
            {
                light2.GetComponent<Light>().color = BingoColor;
                keyPressTimer += Time.deltaTime;
                Debug.Log(keyPressTimer + "\n" + (timeMultiple / 2f));
                if (keyPressTimer >= (timeMultiple / 2f))
                {
                    Destroy(target);
                    timer = KeyBirthTime - 0.5f;
                    getPoints++;
                    keyPressTimer = 0;
                    light2.GetComponent<Light>().color = BingoColor;
                }
            }
            else
            {
               // wrong++;
            }
        }
        if (dataInterface.fingerData[3] >= curvatureValue)//无名指
        {
            light3.GetComponent<Light>().color = keydownColor;
            light3.SetActive(true);
            Debug.Log("key3");
            if (target != null && targetNumber == 3)
            {
                light3.GetComponent<Light>().color = BingoColor;
                keyPressTimer += Time.deltaTime;
                Debug.Log(keyPressTimer + "\n" + (timeMultiple / 2f));
                if (keyPressTimer >= (timeMultiple / 2f))
                {
                    Destroy(target);
                    timer = KeyBirthTime - 0.5f;
                    getPoints++;
                    keyPressTimer = 0;
                    light3.GetComponent<Light>().color = BingoColor;
                }
            }
            else
            {
                //wrong++;
            }
        }
        if (dataInterface.fingerData[4] >= curvatureValue)//小拇指
        {
            light4.GetComponent<Light>().color = keydownColor;
            light4.SetActive(true);
            Debug.Log("key4");
            if (target != null && targetNumber == 4)
            {
                light4.GetComponent<Light>().color = BingoColor;
                keyPressTimer += Time.deltaTime;
                Debug.Log(keyPressTimer + "\n" + (timeMultiple / 2f));
                if (keyPressTimer >= (timeMultiple / 2f))
                {
                    Destroy(target);
                    timer = KeyBirthTime - 0.5f;
                    getPoints++;
                    keyPressTimer = 0;
                    light4.GetComponent<Light>().color = BingoColor;
                }
            }
            else
            {
                //wrong++;
            }
        }

        //-------------
        if (timer >= KeyBirthTime && TimeOut == 0)
        {
            int i = Random.Range(0, 5);//随机调用生成光键
            timeMultiple = Random.Range(1, 5);//随机生成光键后缀长度
            InstantiateNewKey(i);
            timer = 0;
        }

        if (gameTimer >= gameTime)//音乐结束后延迟结束游戏
        {
            gameTimer = 0;
            TimeOut = 1;
            Invoke("GameStop", KeyBirthTime);
        }
        //---
        //Debug.Log(gameTime + "\n" + gameTimer + "\n" + Time.deltaTime);
    }

    void InstantiateNewKey(int i)
    {
        switch (i)//生成光键
        {
            case 0: { Instantiate(key0); break; }
            case 1: { Instantiate(key1); break; }
            case 2: { Instantiate(key2); break; }
            case 3: { Instantiate(key3); break; }
            case 4: { Instantiate(key4); break; }
            default: { break; }
        }
    }

    void GameStop()//结束游戏
    {
        saveData.writeData();
        startCam.SetActive(true);
        music.SetActive(false);
        imgL.SetActive(true);
        imgR.SetActive(true);
        
        startPanel.SetActive(true);
        isGameStart = 0;
        gameObject.SetActive(false);
    }
}
