using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class settingCtrl : MonoBehaviour
{
    public GameObject UIsetting;
    public static AudioSource music;
    public static int isStop = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (mainCtrl.isGameStart == 0)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (isStop)
            {
                case 0://暂停
                    {
                        isStop = 1;
                        music.Pause();
                        UIsetting.SetActive(true);
                        Time.timeScale = 0;
                        break;
                    }
                case 1://继续
                    {
                        isStop = 0;
                        music.Play();
                        UIsetting.SetActive(false);
                        Time.timeScale = 1;
                        break;
                    }
            }
        }
    }
   
}
