using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Yarn.Unity;

public class Power : MonoBehaviour
{
    private Volume _volume;
    
    private Savefile _savefile;
    private Slider _slider;

    private void Start()
    {
        _savefile = GameObject.Find("Savefile").GetComponent<Savefile>();
        
        if(_slider == null)
            _slider = gameObject.GetComponent<Slider>();
        
        adaptVisualsToPower();
        SceneManager.sceneLoaded += SceneManagerOnsceneLoaded;
    }

    private void SceneManagerOnsceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        adaptVisualsToPower();
    }

    public void adaptVisualsToPower()
    {
        // this script will travel through different scenes 
        // therefore its best to search the Volume+Components every time
        GameObject fadeOut = GameObject.Find("FadeOut");
        if (fadeOut != null)
        {
            _volume = fadeOut.GetComponent<Volume>();
            ColorAdjustments colorAdjustments = (ColorAdjustments) _volume.profile.components.FirstOrDefault(f => f is ColorAdjustments);
            FilmGrain filmGrain = (FilmGrain) _volume.profile.components.FirstOrDefault(f => f is FilmGrain);

            if (colorAdjustments != null) colorAdjustments.saturation.value = _slider.value * -1;
            if (filmGrain != null) filmGrain.intensity.value = _slider.value / 100;
        }
    }

    [YarnCommand("addSlider")]
    public void AddSlider(string value)
    {
        NumberFormatInfo format = NumberFormatInfo();

        _slider.value += float.Parse(value, format);
        Savefile.power = _slider.value;
        
        adaptVisualsToPower();
    }

    private static NumberFormatInfo NumberFormatInfo()
    {
        var format = new NumberFormatInfo();
        format.NegativeSign = "-";
        format.NumberDecimalSeparator = ".";
        return format;
    }

    [YarnCommand("setSlider")]
    public void ChangeSlider(string value)
    {
        NumberFormatInfo format = NumberFormatInfo();

        if(_slider == null) _slider = gameObject.GetComponent<Slider>();
        
        _slider.value = float.Parse(value, format);
    }
}
