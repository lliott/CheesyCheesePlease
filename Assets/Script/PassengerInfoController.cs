using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassengerInfoController : MonoBehaviour
{
    public static PassengerInfoController instance;
    [SerializeField] private Image _imgPhoto;
    [SerializeField] private Text _txtName;
    [SerializeField] private Text _txtCaption; 
    [SerializeField] private Image _imgSkin;
    [SerializeField] private Image _imgGift;
    [SerializeField] private Text _textDialogue;

    //Index
    [SerializeField] private int index;

    //Database && Script
    [SerializeField] private PassengerDatabase _passengerDatabase;
    [SerializeField] private Offrandes _offrandesScript;

    void Start(){
         if (instance != null) 
        { 
            Destroy(instance); 
        } 
        else 
        { 
            instance = this; 
        } 

        _imgGift.gameObject.SetActive(false);
    }

    //Appelé dans RoundManager
    public void UpdatePassengerInfo(PassengerData data)
    {
        _imgPhoto.sprite = data.passportSettings.photo;
        _txtName.text = data.name;
        _txtCaption.text = data.passportSettings.caption;
        _imgSkin.sprite = data.skin;
        _textDialogue.text = data.dialogue;
    }

    public void SetIndex(int nextIndex)
    {
        index = nextIndex;
    }

    public void IncrementIndex()
    {
        if (index < _passengerDatabase.datas.Count)
        {
            index++;
        }
        else
        {
            Debug.Log("can't increment further");
        }
    }

//Si dialogue déclenché > give gift
    public void GiveGift(){
        _imgGift.gameObject.SetActive(true);
        _imgGift.sprite = _offrandesScript.UpdateGiftImage(RoundManager.instance.currentPassenger.gift);
    }
}
