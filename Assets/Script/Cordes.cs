using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cordes : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerExitHandler
{
    [SerializeField] private float pullThreshold = -50f;   // Seuil 
    [SerializeField] private float reboundDistance = 10f;  
    [SerializeField] private float reboundDuration = 0.2f; 
    [SerializeField] private float resetDuration = 0.5f;
    [SerializeField] private bool accept;
    private RectTransform ropeTransform;  
    private Vector2 startPosition;                         
    private bool isTriggered = false;                     
    private bool hasRebounded = false;     

    //Audio
    private AudioSource _audio;                

    void Start()
    {
        ropeTransform = GetComponent<RectTransform>();
        _audio = GetComponent<AudioSource>();

        startPosition = ropeTransform.anchoredPosition;
        
    }

    
    public void OnDrag(PointerEventData eventData)
    {
        if (isTriggered && hasRebounded) return;

        Vector2 newPosition = ropeTransform.anchoredPosition + new Vector2(0, eventData.delta.y);

        // pas remonter plus haut que point de départ
        if (newPosition.y > startPosition.y)
        {
            newPosition.y = startPosition.y;
        }

        // blocage au seuil
        if (newPosition.y < startPosition.y + pullThreshold)
        {
            newPosition.y = startPosition.y + pullThreshold;
        }

        ropeTransform.anchoredPosition = newPosition;

        // si seuil : apl fonction
        if (!isTriggered && ropeTransform.anchoredPosition.y <= startPosition.y + pullThreshold)
        {
            TriggerLever();
        }
    }

    // Qd relache
    public void OnPointerUp(PointerEventData eventData)
    {
        // Si seuil lancer rebond
        if (isTriggered && !hasRebounded)
        {
            hasRebounded = true;
            StartCoroutine(Rebound());
        }
        else
        {
            ropeTransform.anchoredPosition = startPosition;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isTriggered && !hasRebounded)
        {
            hasRebounded = true; 
            StartCoroutine(Rebound());
        }
    }

    // rebond
    private IEnumerator Rebound()
    {
        _audio.Play();
        Vector2 targetPosition = ropeTransform.anchoredPosition + new Vector2(0, reboundDistance); // Position cible pour le rebond
        float elapsedTime = 0f;

        while (elapsedTime < reboundDuration)
        {
            elapsedTime += Time.deltaTime;
            ropeTransform.anchoredPosition = Vector2.Lerp(ropeTransform.anchoredPosition, targetPosition, elapsedTime / reboundDuration);
            yield return null;
        }

        // blocage à la position du rebond
        ropeTransform.anchoredPosition = targetPosition;
    }

    void TriggerLever()
    {
        isTriggered = true;
        Debug.Log("Corde tirée ");
        if(accept){
            FinalChecking.instance.Accept();
        } else{
            FinalChecking.instance.Refuse();
        }
    }

    public void ResetRope()
    {
        StartCoroutine(ResetRopeCoroutine());
    }

    private IEnumerator ResetRopeCoroutine()
    {
        Vector2 targetPosition = startPosition; 
        float elapsedTime = 0f;

        while (elapsedTime < resetDuration) 
        {
            elapsedTime += Time.deltaTime;
            ropeTransform.anchoredPosition = Vector2.Lerp(ropeTransform.anchoredPosition, targetPosition, elapsedTime / resetDuration);
            yield return null;
        }

        ropeTransform.anchoredPosition = targetPosition;

        //Reinit values
        isTriggered = false;
        hasRebounded = false;
    }
}
