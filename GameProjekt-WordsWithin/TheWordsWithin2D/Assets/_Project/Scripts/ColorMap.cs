using System;
using System.Collections;
using System.Collections.Generic;
using _Project.Scripts.Player;
using UnityEngine;

public class ColorMap : MonoBehaviour
{
    public Color activeColor;
    public bool activateColor;
    public string runSound = "run";
    private string runDefaultSound = "run";

    private void OnTriggerEnter2D(Collider2D other)
    {
        activateColor = true;
        PlayerMovement.runSoundName = runSound;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        activateColor = false;
        PlayerMovement.runSoundName = runDefaultSound;
    }
}
