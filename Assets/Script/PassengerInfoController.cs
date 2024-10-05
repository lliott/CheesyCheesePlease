using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassengerInfoController : MonoBehaviour
{
    [SerializeField] private Image _imgPhoto;
    [SerializeField] private Text _txtName;
    [SerializeField] private Text _txtCaption; // TMP_Text
    [SerializeField] private int index;

    //Database
    [SerializeField] private PassengerDatabase _passengerDatabase;

    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        PassengerData data = _passengerDatabase.datas[index];

        _imgPhoto.sprite = data.passportSettings.photo;
        _txtName.text = data.name ;
        _txtCaption.text = data.passportSettings.caption;
    }

    void UdpateUI()
    {
    }
}
