using UnityEngine;
using System.Collections;

public class light1 : MonoBehaviour {
    public static float time = 0;
    //public static GameObject thislight;
    public GameObject light;
    void Start()
    {
        time = 0;
        mainCtrl.light1 = gameObject;
    }
    
    void Update()
    {
        Debug.Log("ligh1on");
        time += Time.deltaTime;
        if (time >=mainCtrl.LightOnTime)
        {
            time = 0;
            light.SetActive(false);
        }
    }
}
