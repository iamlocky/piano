using UnityEngine;
using System.Collections;

public class light4 : MonoBehaviour {
    public static float time = 0;
    //public static GameObject thislight;
    public GameObject light;
    void Start()
    {
        time = 0;
        mainCtrl.light4 = gameObject;
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= mainCtrl.LightOnTime)
        {
            time = 0;
            light.SetActive(false);
        }
    }
}
