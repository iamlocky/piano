using UnityEngine;
using System.Collections;

public class toast : MonoBehaviour {
    public static float timer;
	// Use this for initialization
	void Start () {
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer>=.4)
        {
            gameObject.SetActive(false);
            timer = 0;
        }
	}
}
