using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class SetActiveAndInactive : MonoBehaviour
{
    [YarnCommand("setActive")]
    public void setActive(string componentName)
    {
        GameObject.Find(componentName).GetComponent<SpriteRenderer>().enabled = true;
    }
    
    [YarnCommand("setInactive")]
    public void setInactive(string componentName)
    {
        GameObject.Find(componentName).GetComponent<SpriteRenderer>().enabled = false;
    }
}
