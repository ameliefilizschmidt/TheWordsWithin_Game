using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightSwitch : MonoBehaviour
{
    private bool inRange = false;
    private bool ePressed = false;
    private Light2D _light;

    private void Start()
    {
        _light = gameObject.GetComponent<Light2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        inRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        inRange = false;
    }
    
    private void Update()
    {
        ePressed = Input.GetKeyDown(KeyCode.E);
        
        if (inRange && ePressed)
            _light.enabled = !_light.enabled;
    }
}
