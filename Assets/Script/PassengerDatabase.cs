using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Passenger", menuName= "Database/Passenger", order = 0)]
public class PassengerDatabase : ScriptableObject
{
    public List<PassengerData> datas = new List<PassengerData>();
}
