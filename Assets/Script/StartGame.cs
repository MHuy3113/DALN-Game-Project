using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject start;
    public void StartGameButton()
    {
        start.SetActive(false);
    }
    public void QuitGameButton()
    {
        Application.Quit();
    }
}
