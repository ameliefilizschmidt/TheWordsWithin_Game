using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FightSelector : MonoBehaviour
{
    private Slider _slider;

    private void Start()
    {
        _slider = gameObject.GetComponent<Slider>();
        
    }

    public void moveLeft()
    {
        int power = 1;
        power += Convert.ToInt32(Savefile.power / 30);
        
        _slider.value -= power;
        
        if(Math.Abs(_slider.value - _slider.minValue) < tolerance)
        {
            Savefile.looseDialogue = "";

            PlayerPrefs.SetString("scene", Savefile.continueInThisSceneAfterFight);
            PlayerPrefs.Save();
            FindObjectOfType<AudioManager>().Stop("FightMusic");
            SceneManager.LoadScene(Savefile.continueInThisSceneAfterFight);
        }
            
    }

    public double tolerance = 0.01f;

    public void moveRight()
    {
        _slider.value += 1;
        
        if(Math.Abs(_slider.value - _slider.maxValue) < tolerance)
        {
            Savefile.winDialogue = "";

            PlayerPrefs.SetString("scene", Savefile.continueInThisSceneAfterFight);
            PlayerPrefs.Save();

            FindObjectOfType<AudioManager>().Stop("FightMusic");
            SceneManager.LoadScene(Savefile.continueInThisSceneAfterFight);
        }
    }
}
