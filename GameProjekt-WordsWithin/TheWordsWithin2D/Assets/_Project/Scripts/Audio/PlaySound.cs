using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public string sound = "";
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (sound != "")
        {
            FindObjectOfType<AudioManager>().Play(sound);
        }
       
    }
}
