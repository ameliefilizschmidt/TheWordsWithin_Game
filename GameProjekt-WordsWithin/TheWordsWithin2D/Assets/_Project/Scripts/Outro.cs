using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Outro : MonoBehaviour
{
    public string nextScene;
    
    private PlayableDirector _timeline;
    
    void Start()
    {
        _timeline = GameObject.Find("TimeLine").GetComponent<PlayableDirector>();
    }

    private void FixedUpdate()
    {
        if (_timeline.state == PlayState.Paused)
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
