using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour
{
    public static RoundManager instance; // Singleton

    [Header("Database")]
    [SerializeField] private PassengerDatabase passengerDatabase;
    [SerializeField] private PassengerInfoController passengerInfoController;

    [Header("Passenger & Round settings")]
    public PassengerData currentPassenger;
    [SerializeField] private GameObject tutorialToDisplay;

    private List<PassengerData> passengersToDisplay;
    private int currentPassengerIndex = 0;
    private int currentRound = 1;

    [SerializeField] private Button nextPassengerButton;
    [SerializeField] private int totalPassengersPerRound = 10;
    [SerializeField] private int totalRounds = 1;

    [Header("Scripts")]
    [SerializeField] private Temperature _temperatureScript;
    [SerializeField] private Offrandes _offrandesScript;
    [SerializeField] private List<Cordes> _ropesList= new List<Cordes>();

    [Header("Passenger Stuff")]
    [SerializeField] GameObject passport;
    [SerializeField] GameObject offrande;
    [SerializeField] GameObject dialogue;

    [Header("Passenger Image Settings")]
    [SerializeField] private Image passengerImage;
    [SerializeField] private Vector3 imageOffset = new Vector3(20f, 0f, 0f);
    [SerializeField] private float fadeDuration = 2.0f;
    [SerializeField] private float delayBeforeFade = 0.5f;
    public bool isAccepted;

    private Vector3 originalPosition;
    private Color originalColor;

    //Audio
    private AudioSource _audio;

    void Start()
    {
        tutorialToDisplay.SetActive(true);

        if (instance != null)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }
        _audio = GetComponent<AudioSource>();

        originalPosition = passengerImage.transform.localPosition;
        originalColor = passengerImage.color;

        StartNewRound();
        _offrandesScript.GenerateForbiddenGift(); //Generate new gift
        _temperatureScript.GetFourRandomInterdictions(); //Generate new interdictions
        _temperatureScript.DisplayInterdictions();
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

        // Each passenger is chosen once
        passengers.AddRange(availablePassengers);
        int remainingPassengers = totalPassengersPerRound - availablePassengers.Count;

        for (int i = 0; i < remainingPassengers; i++)
        {
            int randomIndex = Random.Range(0, availablePassengers.Count);
            passengers.Add(availablePassengers[randomIndex]);
        }

        // Shuffle
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
        foreach(var rope in  _ropesList){
            rope.Invoke("ResetRope",1f); //reset l etat des cordes
        }
        if(_temperatureScript.isClickable){
            _temperatureScript.RemoveScanner();
        }

        if (currentPassengerIndex < totalPassengersPerRound)
        {
            StartCoroutine(TransitionToNextPassenger());
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
                Results.instance.ConcludeGame();
            }
        }
    }

    private IEnumerator TransitionToNextPassenger()
    {
        if (currentPassengerIndex > 0)
        {
            yield return StartCoroutine(HidePassengerImageWithFade());
        }

        currentPassenger = passengersToDisplay[currentPassengerIndex];
        passengerInfoController.UpdatePassengerInfo(currentPassenger);
        passengerInfoController.SetIndex(currentPassengerIndex);

        yield return StartCoroutine(ShowPassengerImageWithFade());

        ActivatePassport();
        currentPassengerIndex++;
        isAccepted = false;
    }

    private IEnumerator HidePassengerImageWithFade()
    {
        DeactivateStuff();

        Vector3 currentPosition = passengerImage.transform.localPosition;
        Vector3 targetPosition = originalPosition;
        Vector3 targetPositionAccepted = originalPosition + (imageOffset * 2);

        Color currentColor = passengerImage.color;
        Color targetColor = Color.black;

        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);

            if (!isAccepted)
            {
                passengerImage.transform.localPosition = Vector3.Lerp(currentPosition, targetPosition, t);

            } else {

                passengerImage.transform.localPosition = Vector3.Lerp(currentPosition, targetPositionAccepted, t);
            }


            passengerImage.color = Color.Lerp(currentColor, targetColor, t);

            yield return null;
        }

        passengerImage.transform.localPosition = targetPosition;
        passengerImage.color = targetColor;
    }

    private IEnumerator ShowPassengerImageWithFade()
    {
        _audio.Play();
        passengerImage.transform.localPosition = originalPosition;

        Vector3 initialPosition = originalPosition;
        Vector3 targetPosition = initialPosition + imageOffset;

        passengerImage.color = Color.black;

        yield return new WaitForSeconds(delayBeforeFade);

        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);

            passengerImage.transform.localPosition = Vector3.Lerp(initialPosition, targetPosition, t);

            passengerImage.color = Color.Lerp(Color.black, originalColor, t);

            yield return null;
        }

        passengerImage.transform.localPosition = targetPosition;
        passengerImage.color = originalColor;
    }

    private void ActivatePassport()
    {
        passport.SetActive(true);
    }

    private void DeactivateStuff()
    {
        passport.SetActive(false);
        offrande.SetActive(false);
        dialogue.SetActive(false);
    }


}
