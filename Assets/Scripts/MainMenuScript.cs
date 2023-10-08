using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        Application.LoadLevel("Level1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
