﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuArena : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void backToMenu(){

		Debug.Log ("cliquei no botao de menu da arena");
		SceneManager.LoadScene ("Menu");
	}
}
