using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class FreundAnimation : MonoBehaviour
{
    public Sprite idleSprite;
    
    
    [YarnCommand("stopFreund")]
    public void stopFreund()
    {
        gameObject.GetComponent<Animator>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = idleSprite;
    }
}
