using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using Random = UnityEngine.Random;

public class LightFlicker : MonoBehaviour
{
    public int flickerSpeed = 1;
    private Light2D _light;

    private void Start()
    {
        _light = gameObject.GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( Random.value > (0.99 + 0.009 * 1 / Math.Abs(flickerSpeed)) ) //a random chance
        {
            _light.enabled = !_light.enabled;
        }
    }
}
