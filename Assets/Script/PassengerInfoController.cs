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

    //Database
    [SerializeField] private PassengerDatabase _passengerDatabase;

    void Start(){
         if (instance != null) 
        { 
            Destroy(instance); 
        } 
        else 
        { 
            instance = this; 
        } 
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
}
