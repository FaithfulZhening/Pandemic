﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveOperation : MonoBehaviour {
    public Button driveButton;
    public Button directFlightButton;
    public Button shuttleFlightButton;
    public Button charterFlightButton;
    public Button cancelButton;
    
    Game game;

    Player currentPlayer;

    private enum Status {DRIVE, DIRECTFLIGHT, SHUTTLEFLIGHT, CHARTERFLIGHT};

    private Status moveStatus = Status.DRIVE; 

    void Start()
    {
        game = GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>();
    }

    public void moveButtonClicked()
    {
        currentPlayer = game.getCurrentPlayer();
        driveButton.GetComponent<Button>().interactable = true;
        City currentCity = currentPlayer.getPlayerPawn().getCity();

        if (currentPlayer.containsCityCard())
        {
            directFlightButton.GetComponent<Button>().interactable = true;
        }
        if (currentPlayer.containsSpecificCityCard(currentCity))
        {
            charterFlightButton.GetComponent<Button>().interactable = true;
        }
        if (currentCity.getHasResearch())
        {
            shuttleFlightButton.GetComponent<Button>().interactable = true;
        }
        cancelButton.GetComponent<Button>().interactable = true;
    }

    public void cancelButtonClicked()
    {
        disableAllCities();
    }
   // public City tmpCity;
    public void driveButtonClicked()
    {
        driveButton.GetComponent<Button>().interactable = false;
        directFlightButton.GetComponent<Button>().interactable = false;
        charterFlightButton.GetComponent<Button>().interactable = false;
        shuttleFlightButton.GetComponent<Button>().interactable = false;
        currentPlayer = game.getCurrentPlayer();
        City currentCity = currentPlayer.getPlayerPawn().getCity();
        Debug.Log(currentCity.getCityName());
        foreach (City neighbor in currentCity.getNeighbors())
        {
            Debug.Log(neighbor.getCityName());
            neighbor.displayButton();
        }
        moveStatus = Status.DRIVE;
    }

    public void directFlightButtonClicked()
    {
        driveButton.GetComponent<Button>().interactable = false;
        directFlightButton.GetComponent<Button>().interactable = false;
        charterFlightButton.GetComponent<Button>().interactable = false;
        shuttleFlightButton.GetComponent<Button>().interactable = false;
        currentPlayer = game.getCurrentPlayer();
        City currentCity = currentPlayer.getPlayerPawn().getCity();
        List<PlayerCard> cards = currentPlayer.getHand();
        foreach(CityCard card in cards)
        {
            City city = card.getCity();
            if (city != currentCity)
            {
                city.displayButton();
            }
        }

        moveStatus = Status.DIRECTFLIGHT;
    }

    public static void disableAllCities()
    {
        GameObject[] tmp = GameObject.FindGameObjectsWithTag("City");
        foreach (GameObject aObject in tmp)
        {
            Button button = aObject.GetComponent<Button>();
            if (button.interactable)
            {
                button.interactable = false;
            }
        }
    }
    

    // for testing only
    public void cityButtonClicked(City destinationCity)
    {
        currentPlayer = game.getCurrentPlayer();
        if(moveStatus == Status.DRIVE)
        {
            game.drive(currentPlayer, destinationCity);
        }
        else if(moveStatus == Status.DIRECTFLIGHT)
        {
            game.takeDirectFlight(currentPlayer, currentPlayer.getCard(destinationCity));
        }
        disableAllCities();
    }


}