using UnityEngine;
using System.Collections;

public class MoveUpOverTime : MonoBehaviour
{
    public float moveAmount = 1100f;   // Total distance to move upward in pixels
    public float duration = 1f;      // Duration over which the movement occurs

    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        StartCoroutine(MoveUp());
    }

    IEnumerator MoveUp()
    {
        Vector2 startPosition = rectTransform.anchoredPosition;
        Vector2 endPosition = startPosition + new Vector2(0, moveAmount);
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // Calculate the new position using linear interpolation
            rectTransform.anchoredPosition = Vector2.Lerp(startPosition, endPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null; // Wait until the next frame
        }

        // Ensure the UI object reaches the exact end position
        rectTransform.anchoredPosition = endPosition;
    }
}
