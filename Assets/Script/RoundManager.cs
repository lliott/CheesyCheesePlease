using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour
{
    [SerializeField] private PassengerDatabase passengerDatabase;
    [SerializeField] private PassengerInfoController passengerInfoController;
    [SerializeField] private Button nextPassengerButton;
    [SerializeField] private int totalPassengersPerRound = 10;
    [SerializeField] private int totalRounds = 1;

    private List<PassengerData> passengersToDisplay;
    private int currentPassengerIndex = 0;
    private int currentRound = 1;

    void Start()
    {
        nextPassengerButton.onClick.AddListener(ShowNextPassenger);
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

    void ShowNextPassenger()
    {
        Debug.Log("Showing next passenger");

        if (currentPassengerIndex < passengersToDisplay.Count)
        {
            PassengerData currentPassenger = passengersToDisplay[currentPassengerIndex];
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
