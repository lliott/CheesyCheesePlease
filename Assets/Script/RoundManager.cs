using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour
{
    public static RoundManager instance; //Singleton

    [Header("Database")]
    [SerializeField] private PassengerDatabase passengerDatabase;
    [SerializeField] private PassengerInfoController passengerInfoController;

    public PassengerData currentPassenger;
    
    //
    [SerializeField] private Button nextPassengerButton;
    [SerializeField] private int totalPassengersPerRound = 10;
    [SerializeField] private int totalRounds = 1;

    [Header("Température")]
    [SerializeField] private Temperature _temperatureScript;

    private List<PassengerData> passengersToDisplay;
    private int currentPassengerIndex = 0;
    private int currentRound = 1;

    void Start()
    {
        if (instance != null) 
        { 
            Destroy(instance); 
        } 
        else 
        { 
            instance = this; 
        } 

        //nextPassengerButton.onClick.AddListener(ShowNextPassenger);
        StartNewRound();
    }

    void StartNewRound()
    {
        Debug.Log("New round started");
        currentPassengerIndex = 0;
        passengersToDisplay = GeneratePassengerList();
        ShowNextPassenger();
    }

    List<PassengerData> GeneratePassengerList()
    {
        List<PassengerData> passengers = new List<PassengerData>();
        List<PassengerData> availablePassengers = new List<PassengerData>(passengerDatabase.datas);

        // each passenger is chosen once
        passengers.AddRange(availablePassengers);
        int remainingPassengers = totalPassengersPerRound - availablePassengers.Count;

        for (int i = 0; i < remainingPassengers; i++)
        {
            int randomIndex = Random.Range(0, availablePassengers.Count);
            passengers.Add(availablePassengers[randomIndex]);
        }

        // shuffle
        for (int i = 0; i < passengers.Count; i++)
        {
            PassengerData temp = passengers[i];
            int randomIndex = Random.Range(i, passengers.Count);
            passengers[i] = passengers[randomIndex];
            passengers[randomIndex] = temp;
        }

        return passengers;
    }

    public void ShowNextPassenger()
    {
        Debug.Log("Showing next passenger");

        //Reset game
        PassengerInfoController.instance.UpdatePassengerInfo(currentPassenger);
        _temperatureScript.GenerateResults(); //Générer une nouvelle température (gift) par nv pers

        if (currentPassengerIndex < passengersToDisplay.Count)
        {
            currentPassenger = passengersToDisplay[currentPassengerIndex];
            passengerInfoController.UpdatePassengerInfo(currentPassenger);
            passengerInfoController.SetIndex(currentPassengerIndex);
            currentPassengerIndex++;
        }
        else
        {
            currentRound++;
            if (currentRound <= totalRounds)
            {
                StartNewRound();
            }
            else
            {
                Debug.Log("All rounds completed!");
                Debug.Log("FINITO");
            }
        }
    }
}
