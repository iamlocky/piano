using UnityEngine;
using System.Collections;

public class miss : MonoBehaviour {
    public static float timer;
	// Use this for initialization
	void Start () {
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.fixedDeltaTime;
        if(timer>=.5)
        {
            Destroy(gameObject);
        }
	}
}
