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
    private List<PassengerData> terroristList = new List <PassengerData>();
    private int indexTerrorist;

    void Start ()
    {
        for (int i = 0; i < passengerDatabase.datas.Count; i++)
        {
            PassengerData data = passengerDatabase.datas[i];

            if (data != null && data.passengerType == PassengerType.Terrorist)
            {
                Debug.Log("BBBBBBBBH");
                imgPhoto.sprite = data.passportSettings.photo;
                txtName.text = data.name;
                txtEnum.text = data.passengerType.ToString();
                terroristList.Add(data);
            }
        }
    }

    public void UpdateTerroristInfo(PassengerData data)
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

    public void Next()
    {
        if (indexTerrorist < terroristList.Count - 1)
        {
            indexTerrorist++;

        } else {

            indexTerrorist = 0;
        }

        UpdateTerroristInfo(terroristList[indexTerrorist]);
    }

    public void Previous()
    {
        if (indexTerrorist == 0)
        {
            indexTerrorist = terroristList.Count - 1;

        } else { 

            indexTerrorist--;
        }

        UpdateTerroristInfo(terroristList[indexTerrorist]);
    }


    //A appeler ds la verif finale à la fin de chq round
    public bool isTerrorist(){
        PassengerData currentPassenger = RoundManager.instance.currentPassenger;
        Debug.Log("name :" + currentPassenger.name);
        if(currentPassenger.passengerType == PassengerType.Terrorist){
            return true;
        }
        return false;
    }
}
