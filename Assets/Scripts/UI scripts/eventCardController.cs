﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class eventCardController : MonoBehaviour {
	string name;
	public Game game;
	Player currentPlayer;
	City currentCity;
	public GameObject informEvent;

	//Resilient zone
	public GameObject infectionDiscardPile;
	string resilientCard;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {		
	}

	private void borrowedTime(){
		currentPlayer = game.getCurrentPlayer();
		game.BorrowedTime ();
	}
	//---------------------------------Resilient zone-----------------------------------

	private void ResilientPopulation(){
		foreach (Transform t in infectionDiscardPile.transform.GetChild(0).GetChild(0)) {
			if (t.gameObject.GetComponent<Button> () == null) {
				t.gameObject.AddComponent<Button> ();
				t.GetComponent<Button> ().interactable = true;
				Button b = t.GetComponent<Button> ();
				b.onClick.AddListener (resilientSelectCard);
			}
		}
		infectionDiscardPile.SetActive (true);
	}
	public void resilientSelectCard(){
		resilientCard=EventSystem.current.currentSelectedGameObject.name;
		//game.resilientPopulation();
	}
	public void resolveResilientSelect(){
		
	}
	//------------------------------Resilient zone end-----------------------------------

	public void useEvent(){
		name = this.transform.GetChild (1).GetComponent<Text> ().text;
		Debug.Log (name);
		switch (name)
		{
		case "BorrowedTime":
			borrowedTime ();
			break;
		case "ResilientPopulation":
			ResilientPopulation ();
			break;
		default:
			
			break;
		}
		/*
		Airlift
		ResilientPopulation
		OneQuietNight
		Forecast
		GovernmentGrant
		CommercialTravelBan
		ReExaminedResearch
		RemoteTreatment
		BorrowedTime
		MobileHospital
		NewAssignmentRapidVaccineDeployment*/
	}
}
