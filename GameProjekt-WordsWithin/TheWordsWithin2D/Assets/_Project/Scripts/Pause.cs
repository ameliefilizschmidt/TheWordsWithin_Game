using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Pause : MonoBehaviour
{
    public Volume volume;
    public GameObject ui;
    
    private UnityEngine.Rendering.Universal.DepthOfField _depthOfField;

    private void Start()
    {
        _depthOfField = (UnityEngine.Rendering.Universal.DepthOfField) volume.profile.components[1];
        ui.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SetPause();
    }

    private void SetPause()
    {
        _depthOfField.active = true;
        Time.timeScale = 0;
        ui.SetActive(true);
    }

    public void UnPause()
    {
        _depthOfField.active = false;
        ui.SetActive(false);
        Time.timeScale = 1;
    }
}
