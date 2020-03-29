using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    void Awake()
    {
        SaveData.current = (SaveData) SerializationManager.Load();

        Debug.Log(SaveData.current.isLevelCompleted[Level.Staircase]);
        Debug.Log(SaveData.current.isLevelCompleted[Level.ParkingLot]);
        Debug.Log(SaveData.current.isLevelCompleted[Level.DarkRoom]);

        if (!SaveData.current.isLevelCompleted[Level.Staircase])
        {
            GameObject.Find("Car").SetActive(false);
            Debug.Log("Car inactive.");
        }

        if (!SaveData.current.isLevelCompleted[Level.ParkingLot])
        {
            GameObject.Find("DarkRoom").SetActive(false);
            Debug.Log("DarkRoom inactive.");
        }

        if (!SaveData.current.isLevelCompleted[Level.DarkRoom])
        {
            GameObject.Find("Pipe").SetActive(false);
            Debug.Log("Pipe inactive.");
        }
    }
}
