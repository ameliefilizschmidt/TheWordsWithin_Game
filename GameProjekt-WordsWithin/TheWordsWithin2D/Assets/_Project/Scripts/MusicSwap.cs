using System;
using System.Collections;
using System.Collections.Generic;
using CsvHelper.Configuration;
using UnityEngine;
using UnityEngine.Audio;

public class MusicSwap : MonoBehaviour
{
    public AudioMixerSnapshot snapshot;
  private void OnTriggerEnter2D(Collider2D other)
    {
        bool isAPlayer = other.gameObject.CompareTag("Player");
        if (isAPlayer)
        {
            ChangeSong();
            Debug.Log("newSnapshot");
        }
        
    }

    private void ChangeSong()
    {
       snapshot.TransitionTo(5f);
    }
    }
