﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundSetupLoader : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SceneManager.LoadScene("SoundSetup", LoadSceneMode.Additive);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
