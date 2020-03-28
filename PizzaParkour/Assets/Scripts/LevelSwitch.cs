using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitch : MonoBehaviour
{

    private InputMaster input;
    private Vector2 movement;

    private void Awake()
    {
        input = new InputMaster();
        input.Player.Restart.started += context => Restart();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Death")
        {
            SceneManager.LoadScene(3);
        }

        if (other.tag == "Customer1")
        {
            SaveProgress();
            SceneManager.LoadScene(3);
        }

        if (other.tag == "Car")
        {
            SceneManager.LoadScene(4);
        }

        if (other.tag == "Stair")
        {
            SceneManager.LoadScene(5);
        }

        if (other.tag == "DarkRoom")
        {
            SceneManager.LoadScene(0);
        }

    }

    private void SaveProgress()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        switch (sceneName)
        {
            case "Staircase":
                SaveData.current.isLevelCompleted[Level.Staircase] = true;
                break;
            case "ParkingLot":
                SaveData.current.isLevelCompleted[Level.ParkingLot] = true;
                break;
            case "DarkRoom":
                SaveData.current.isLevelCompleted[Level.DarkRoom] = true;
                break;
            default:
                Debug.LogErrorFormat("Scene {0} not found.", sceneName);
                break;
        }

        SerializationManager.Save(SaveData.current);
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDestroy()
    {
        input.Dispose();
    }
}
