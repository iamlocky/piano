﻿using UnityEngine;
using System.Collections;

public class music : MonoBehaviour {

	// Use this for initialization
	void Start () {
        mainCtrl.music = gameObject;
        settingCtrl.music=gameObject.GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
