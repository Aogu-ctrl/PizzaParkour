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
            SceneManager.LoadScene(1);
        }

        if (other.tag == "Customer1")
        {
            SceneManager.LoadScene(2);
        }
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
