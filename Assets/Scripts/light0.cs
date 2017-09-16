using UnityEngine;
using System.Collections;

public class light0 : MonoBehaviour
{
    public static float time = 0;
    //public static GameObject thislight;
    public GameObject light;
    void Start()
    {
        time = 0;
        mainCtrl.light0 = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("ligh0on");
        time += Time.deltaTime;
        if (time >= mainCtrl.LightOnTime)
        {
            time = 0;
            light.SetActive(false);
        }
    }
}
