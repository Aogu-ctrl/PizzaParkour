using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        if (!SerializationManager.SaveExists())
        {
            GameObject.Find("Continue Button").SetActive(false);
        }
    }

    public void NewGame()
    {
        SerializationManager.Delete();
        SceneManager.LoadScene(Level.Overview.ToString());
    }

    public void Continue()
    {
        SceneManager.LoadScene(Level.Overview.ToString());
    }
}
