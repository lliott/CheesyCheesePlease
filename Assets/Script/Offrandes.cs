using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Offrandes : MonoBehaviour
{
    [Header("Offrandes possibles")]
    [SerializeField] private Sprite gift01;
    [SerializeField] private Sprite gift02;
    [SerializeField] private Sprite gift03;
    [SerializeField] private Sprite gift04;
    [SerializeField] private Sprite gift05;

    [Header("PlaceHolder Offrande interdite")]
    [SerializeField] private Image forbiddenGift;
    private Gift currentForbiddenGift;

    public Sprite UpdateGiftImage(Gift  gift){
        if(gift == Gift.Gift01){
            return gift01;
        } else if (gift== Gift.Gift02) {
            return gift02;
        }else if (gift == Gift.Gift03){
            return gift03;
        }else if (gift == Gift.Gift04) {
            return gift04;
        }else {
            return gift05;
        }
    }

    public void GenerateForbiddenGift(){
        Gift[] gifts = (Gift[])System.Enum.GetValues(typeof(Gift));
        int randomIndex = Random.Range(0, gifts.Length);
        currentForbiddenGift = gifts[randomIndex];

        forbiddenGift.sprite = UpdateGiftImage(currentForbiddenGift);
    }

    public bool isOffrandeCorrect(){
        Gift gift = RoundManager.instance.currentPassenger.gift;
        if(currentForbiddenGift==gift){
            return false;
        }
        return true;
    }
}


public enum Gift{
        Gift01,
        Gift02,
        Gift03,
        Gift04,
        Gift05,
    }
