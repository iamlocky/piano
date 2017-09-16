using UnityEngine;
using System.Collections;

public class lightKey3 : MonoBehaviour {
    public static GameObject miss;
    public static GameObject long1;
    public static GameObject long2;
    public static GameObject long3;
    // Use this for initialization
    void Start()
    {
        miss = mainCtrl.missAudio;
        long1 = transform.FindChild("long1").gameObject;
        long2 = transform.FindChild("long2").gameObject;
        long3 = transform.FindChild("long3").gameObject;
        switch (mainCtrl.timeMultiple)
        {
            case 1: destoryLongCube3(); break;
            case 2: destoryLongCube2(); break;
            case 3: destoryLongCube1(); break;
            default: break;
        }
    }
    public void destoryLongCube3()//1倍
    {
        Destroy(long3);
        Destroy(long2);
        Destroy(long1);
    }
    public void destoryLongCube2()//2倍
    {
        Destroy(long3);
        Destroy(long2);
    }
    public void destoryLongCube1()//3倍
    {
        Destroy(long3);
    }


    // Update is called once per frame
    void FixedUpdate () {
        if (mainCtrl.target == null)
        {
            mainCtrl.target = gameObject;
            mainCtrl.targetNumber = 3;
        }
        transform.Translate(Vector3.back * mainCtrl.moveSpeed * Time.deltaTime);
        if(transform.position.z<=-5.15)
        {
            mainCtrl.light3.GetComponent<Light>().color = Color.red;
            mainCtrl.light3.SetActive(true);
            Instantiate(miss);
            mainCtrl.missPoints++;
            mainCtrl.finger3miss++;
            Destroy(gameObject);
        }
    }
}
