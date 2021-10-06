using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public bool Audio;
    public SaveSystem Save;

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void Options()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
