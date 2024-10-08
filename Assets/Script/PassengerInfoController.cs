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

    // Update is called once per frame
    void Update()
    {
        // Ensure the index is within the valid range before accessing the list
        if (_passengerDatabase != null && index >= 0 && index < _passengerDatabase.datas.Count)
        {
            PassengerData data = _passengerDatabase.datas[index];

            if (data != null)
            {
                _imgPhoto.sprite = data.passportSettings.photo;
                _txtName.text = data.name;
                _txtCaption.text = data.passportSettings.caption;
            }
        }
        else
        {
            Debug.Log($"Index out of range: {index}, Passenger Database Count: {_passengerDatabase.datas.Count}");
        }
    }

    public void UpdatePassengerInfo(PassengerData data)
    {
        _imgPhoto.sprite = data.passportSettings.photo;
        _txtName.text = data.name;
        _txtCaption.text = data.passportSettings.caption;
    }

    public void SetIndex(int nexIndex)
    {
        index = nexIndex;
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
