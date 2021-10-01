using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public bool Audio;

    public void ClickSound(){

        GetComponent<AudioSource>().Play();

    }

    public void NewGame(){

        SceneManager.LoadScene(1);
    
    }

    public void Options(){



    }

    public void ExitGame(){

        Application.Quit();

    }

    

}
