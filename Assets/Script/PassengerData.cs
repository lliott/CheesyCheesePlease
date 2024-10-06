using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

public class PassengerData
{
    public string name;
    public PassportSettings passportSettings;
    public Sprite skin;
    public Gift gift; //offrande
    public PassengerType passengerType;
    public string dialogue;
}
