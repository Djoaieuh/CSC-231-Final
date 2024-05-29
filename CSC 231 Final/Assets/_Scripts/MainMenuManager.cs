using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    AudioManager audiomanager;

    void Start()
    {
        audiomanager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void GoToGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
           Application.Quit();
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ButtonSound()
    {
        AudioManager.instance.PlaySFX(audiomanager.Button);
    }
}
