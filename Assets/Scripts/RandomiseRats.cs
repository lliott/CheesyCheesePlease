using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomiseRats : MonoBehaviour
{
    [Header("Rat Details per Scene")]
    [SerializeField] private List<ItemData> allRats;
    [SerializeField] private int maxRats = 10;
    [SerializeField] private ItemData chosenFirstRat;
    private List<ItemData> randomRats;

    private void Start()
    {
        GenerateRandomRatsList();
    }

    private void GenerateRandomRatsList()
    {
        randomRats = new List<ItemData>();

        if (chosenFirstRat != null && allRats.Contains(chosenFirstRat))
        {
            randomRats.Add(chosenFirstRat);

        } else {

            Debug.LogWarning("First rat not set");
        }

        foreach (ItemData item in allRats)
        {
            randomRats.Add(item);
        }

        while (randomRats.Count < maxRats)
        {
            int randomIndex = Random.Range(0, allRats.Count);
            randomRats.Add(allRats[randomIndex]);
        }

        ShuffleList(randomRats);
    }

    void ShuffleList(List<ItemData> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            ItemData temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}
