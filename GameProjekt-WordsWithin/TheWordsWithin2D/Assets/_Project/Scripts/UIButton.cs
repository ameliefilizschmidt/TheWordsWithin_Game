using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButton : MonoBehaviour
{
    public Pause pause;
    public GameObject ui;
    public Savefile savefile;
    
    public void ResumeGame()
    {
        pause.UnPause();
        ui.SetActive(false);
    }
    
    public void OpenSettings()
    {
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void LoadSavegame()
    {
        string scene = PlayerPrefs.GetString("scene");
        
        if(string.IsNullOrWhiteSpace(scene)) return;
        
            FindObjectOfType<AudioManager>().Stop("MenuMusic");
            FindObjectOfType<AudioManager>().Play("MenuENDEMusic");
            SceneManager.LoadScene(scene);
    }

    public void LoadNewGame()
    {
        FindObjectOfType<AudioManager>().Stop("MenuMusic");
        FindObjectOfType<AudioManager>().Play("MenuENDEMusic");
        savefile.resetSettings();
        
        SceneManager.LoadScene("Intro");
    }
}
