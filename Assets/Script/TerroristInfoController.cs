using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Import TextMeshPro namespace

public class TerroristInfoController : MonoBehaviour
{
    [SerializeField] private Image imgPhoto;
    [SerializeField] private TMP_Text txtName;
    [SerializeField] private TMP_Text txtEnum;
    [SerializeField] private PassengerDatabase passengerDatabase;
    private int index;

    void Update()
    {
        if (passengerDatabase != null && index >= 0 && index < passengerDatabase.datas.Count)
        {
            PassengerData data = passengerDatabase.datas[index];

            // Check if the passenger's type is Terrorist
            if (data != null && data.passengerType == PassengerType.Terrorist)
            {
                imgPhoto.sprite = data.passportSettings.photo;
                txtName.text = data.name;
                txtEnum.text = data.passengerType.ToString();
            }
        }
        else
        {
            Debug.Log($"Index out of range: {index}, Passenger Database Count: {passengerDatabase.datas.Count}");
        }
    }

    public void UpdatePassengerInfo(PassengerData data)
    {
        if (data != null && data.passengerType == PassengerType.Terrorist)
        {
            imgPhoto.sprite = data.passportSettings.photo;
            txtName.text = data.name;
            txtEnum.text = data.passengerType.ToString();
        }
        else
        {
            imgPhoto.sprite = null;
            txtName.text = "";
            txtEnum.text = "";
        }
    }

    public void SetIndex(int nextIndex)
    {
        index = nextIndex;
    }
}
