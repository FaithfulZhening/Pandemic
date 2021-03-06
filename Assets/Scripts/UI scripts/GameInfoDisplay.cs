﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInfoDisplay : MonoBehaviour
{
    public Game game;
    public GameObject outbreak;
    public GameObject infection;
	public GameObject cubeLeft;
	public GameObject researchLabLeft;
	public GameObject cardLeft;
	public GameObject mark;
    public List<GameObject> outbreakrates;
    public List<GameObject> infectionrates;

    private void Update()
    {
        if(game.getChallenge() == Challenge.BioTerroist||game.getChallenge() == Challenge.BioTerroistAndVirulentStrain||game.getChallenge() == Challenge.Mutation || game.getChallenge() == Challenge.MutationAndVirulentStrain)
        {
            cubeLeft.transform.GetChild(4).gameObject.SetActive(true);
        }
		int marker = Int32.Parse(mark.transform.GetChild (0).GetComponent<Text> ().text);
		if (marker != game.getMarkersLeft ()) {
			mark.transform.GetChild (0).GetComponent<Text> ().text = game.getMarkersLeft ().ToString ();
		}
    }

    public void eradicate(Color c){
		Transform t = cubeLeft.transform.GetChild (0);
		if (c == Color.black) {
			t = cubeLeft.transform.GetChild (1);
		} else if (c == Color.blue) {
			t = cubeLeft.transform.GetChild (2);
		} else if(c==Color.red){
			t = cubeLeft.transform.GetChild (3);
		}
        else if(c == Color.magenta)
        {
            t = cubeLeft.transform.GetChild(4);
        }
		t.GetChild (1).gameObject.SetActive (false);
		t.GetChild (2).gameObject.SetActive (true);

	}
	public void setSpecialDisease(Color c){
		Debug.Log ("I a here");
		Transform t = cubeLeft.transform.GetChild (0);
		if (c == Color.black) {
			Debug.Log ("black");
			t = cubeLeft.transform.GetChild (1);
		} else if (c == Color.blue) {
			t = cubeLeft.transform.GetChild (2);
			Debug.Log ("black");
		} else if (c == Color.red) {
			t = cubeLeft.transform.GetChild (3);
			Debug.Log ("black");
		} else if (c == Color.magenta) {
			t = cubeLeft.transform.GetChild (4);
			Debug.Log ("black");
		}
		t.GetChild (3).gameObject.SetActive (true);
		Debug.Log ("black");
	}
	public void cure(Color c){
		Transform t = cubeLeft.transform.GetChild (0);
		if (c == Color.black) {
			t = cubeLeft.transform.GetChild (1);
		} else if (c == Color.blue) {
			t = cubeLeft.transform.GetChild (2);
		} else if (c == Color.red) {
			t = cubeLeft.transform.GetChild (3);
		} else if (c == Color.magenta) {
			t = cubeLeft.transform.GetChild (4);
		}
		t.GetChild (1).gameObject.SetActive (true);

	}
	public void changeDiseaseNumber(Color c, int num){
		Transform t = cubeLeft.transform.GetChild (0);
		if (c == Color.black) {
			t = cubeLeft.transform.GetChild (1);
		} else if (c == Color.blue) {
			t = cubeLeft.transform.GetChild (2);
		} else if (c == Color.red) {
			t = cubeLeft.transform.GetChild (3);
		} else if (c == Color.magenta) {
			t = cubeLeft.transform.GetChild (4);
		}
		t.GetChild (0).GetComponent<Text> ().text=num.ToString();


	}

	public void changeCardNumber(int num){
		cardLeft.transform.GetChild (0).GetComponent<Text> ().text=num.ToString();

	}

    public void changeResearchNumber(int num)
    {
        researchLabLeft.transform.GetChild(0).GetComponent<Text>().text = num.ToString();
    }
    public void displayOutbreak()
    {
        int outbreakRate = game.getOutbreakRate();
        for(int i = 1; i < 9; i++)
        {
            if(i == outbreakRate)
            {
                outbreakrates[i-1].SetActive(true);
            }
            else{
                outbreakrates[i-1].SetActive(false);
            }
        }
    }

    public void displayInfectionRate()
    {
        int infectionIndex = game.getInfectionIndex();
        for(int i = 0; i < 7; i++)
        {
            if (i == infectionIndex)
            {
                infectionrates[i].SetActive(true);
                infectionrates[i].transform.GetChild(0).gameObject.GetComponent<Text>().text = game.getInfectionRate().ToString();
            }
            else
            {
                infectionrates[i].SetActive(false);
            }
        }
    }


    
}
