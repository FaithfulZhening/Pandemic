﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginManagement : MonoBehaviour {
	public InputField playerName;
	private string _gameVersion = "0.1";
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnLoginClicked(){
		if (!PhotonNetwork.connected) {
			PhotonNetwork.ConnectUsingSettings (_gameVersion);
			Random.seed = (int)System.DateTime.Now.Ticks;
			PhotonNetwork.playerName = playerName.text + " #" + Random.Range(10000,99999) ;
		}
		PhotonNetwork.automaticallySyncScene = true;
		SceneManager.LoadScene ("Lobby");
	}
}
