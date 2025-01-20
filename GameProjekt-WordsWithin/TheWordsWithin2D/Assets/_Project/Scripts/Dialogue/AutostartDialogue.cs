using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class AutostartDialogue : MonoBehaviour
{
    public String startThisNode;
    
    private void Start()
    {
        DialogueRunner dialogueRunner = GameObject.Find("Dialogue Runner")?.GetComponent<DialogueRunner>();

        if (dialogueRunner != null)
        {
            dialogueRunner.startNode = startThisNode;
            dialogueRunner.StartDialogue();
        }
    }
}
